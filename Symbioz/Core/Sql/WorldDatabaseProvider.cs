using MySql.Data.MySqlClient;
using Symbioz.Core.Startup;
using Symbioz.ORM;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Symbioz.Core
{
    internal static class WorldDatabaseProvider
    {
        public static MySqlConnection Connection { get { return _database.UseProvider(); } }
        private static DatabaseManager _database;

        public static DatabaseManager GetCurrentDatabase { get { return _database; } }



        [StartupInvoke("World Connection", StartupInvokeType.Base)]
        public static void Connect()
        {

            _database = new DatabaseManager(ConfigurationManager.Instance.DatabaseHost,
                                           ConfigurationManager.Instance.DatabaseName,
                                            ConfigurationManager.Instance.DatabaseUser,
                                           ConfigurationManager.Instance.DatabasePassword);
            _database.UseProvider();

        }
        [StartupInvoke(StartupInvokeType.Sql)]
        public static void Load()
        {
            _database.LoadTables(GetTypes());
        }

        /// <summary>
        /// Reload npcs during game (does not add or remove npcs, update their dialogues and actions)
        /// </summary>
        [StartupInvoke("!Sql Npcs",StartupInvokeType.Sql)]
        public static void LoadNpcs()
        {
            _database.LoadTables(GetTypes(), new List<string>(new string[] { "NpcsActions", "NpcsReplies", "NpcsSpawns", "NpcsTemplates" }));
        }

        public static void Disconnect()
        {
            _database.CloseProvider();
        }

        public static Type[] GetTypes()
        {
            return Assembly.GetAssembly(typeof(WorldDatabaseProvider)).GetTypes().ToList().Where(x => x.GetInterface("ITable") != null).ToArray();
        }
    }
}