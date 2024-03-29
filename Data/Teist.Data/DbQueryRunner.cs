﻿namespace Teist.Data
{
    using System;

    using Teist.Data.Common;

    using Microsoft.EntityFrameworkCore;

    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(TeistDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TeistDbContext Context { get; set; }

        public void RunQuery(string query, params object[] parameters)
        {
            this.Context.Database.ExecuteSqlCommand(query, parameters);
        }

        public void Dispose()
        {
            this.Context?.Dispose();
        }
    }
}
