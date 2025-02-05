﻿namespace Midas.Persistence.Services
{
    public record MidasPersistenceSettings
    {
        public required string DatabasePath { get; init; }
        public string PrimaryTableName { get; init; } = "midas";
        public string ForeignKeyTableName { get; init; } = "foreignKeys";
        public string KvsTableName { get; init; } = "kvs";
        public int MaxKvsSearchHits { get; init; } = 5;
        public string TransactionsTableName { get; init; } = "transactions";
        public string TransactionsTagsTableName { get; init; } = "transactionsTags";
        public string TransactionsImportDataTableName { get; init; } = "transactionsImportData";
        public string AccountsTableName { get; init; } = "accounts";
        public string TransactionsImportConfigurationTableName { get; init; } = "importConfigurations";
        public string SupercategoryTableName { get; init; } = "supercategories";
        public bool UseConnectionPooling { get; init; } = true;
    }
}
