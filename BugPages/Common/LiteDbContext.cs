using LiteDB;
using Microsoft.Extensions.Options;
using System;

namespace BugPages.Common
{
    public class LiteDbContext
    {
        public readonly LiteDatabase Database;
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                var client = new LiteDatabase(configs.Value.DatabasePath);
                if (client != null)
                    Database = client;
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }           
    }    
}