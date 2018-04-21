﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MiniEmailApp
{

    public class DatabaseManager
    {
        private static DatabaseManager _instance = null;
        public static DatabaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseManager();
                }
                return _instance;
            }
        }

        private DatabaseManager() { }

        
    }
}
