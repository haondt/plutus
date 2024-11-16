﻿using Haondt.Core.Models;
using Haondt.Web.Core.Components;
using Haondt.Web.Core.Extensions;
using Haondt.Web.Core.Http;
using Haondt.Web.Core.Services;
using SpendLess.Core.Exceptions;
using SpendLess.Core.Extensions;
using SpendLess.Kvs.Services;
using SpendLess.Web.Core.Abstractions;

namespace SpendLess.Kvs.SpendLess.Kvs
{
    public class KvsComponentDescriptorFactory(IKvsService kvs) : IComponentDescriptorFactory
    {
        public IComponentDescriptor Create()
        {
            return new ComponentDescriptor<KvsModel>(ComponentFactory)
            {
                ViewPath = $"~/SpendLess.Kvs/Kvs.cshtml",
            };
        }

        private async Task<(KvsModel, Optional<Action<IHttpResponseMutator>>)> ComponentFactory(IComponentFactory componentFactory, IRequestData requestData)
        {
            if (requestData.Query.TryGetValue<string>("mapping", out var mapping))
            {
                var expanded = await kvs.GetExpandedMapping(mapping);
                return (new KvsLayoutModel { Content = KvsContentModel.FromExpandedMappingDto(expanded) }, new());
            }

            if (requestData.Query.TryGetValue<bool>("launch-select-modal").Or(false) == true)
                return (new KvsModalModel(), new());

            if (requestData.Query.TryGetValue<string>("search", out var searchText))
            {
                if (searchText == "")
                    throw new UserException("Key cannot be empty.");

                Func<string, Action<IHttpResponseMutator>> responseMutatorFactory = k => new HxHeaderBuilder()
                    .PushUrl($"/kvs/{k}")
                    .BuildResponseMutator();

                var key = (await kvs.Search(searchText)).Or(searchText);
                if ((await kvs.Search(searchText)).Test(out var value))
                {
                    var expandedMapping = await kvs.GetExpandedMapping(value);
                    var model = KvsInsertContentModel.FromExpandedMappingDto(expandedMapping);
                    return (model, responseMutatorFactory(expandedMapping.Key));
                }
                else
                {
                    return (new KvsInsertContentModel { Key = key }, responseMutatorFactory(key));
                }
            }

            return (new KvsLayoutModel(), new());
        }
    }
}
