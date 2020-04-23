using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

namespace BlabberApp.DataStore.Plugins {
    public class MySqlBlab : IBlabPlugin {
        private MySqlConnection _dcBlab;

        public MySqlBlab() {
            _dcBlab = new MySqlConnection("server=142.93.114.73;database=bubbafett1936;user=bubbafett1936;password=5h03b46Z23o5");
            try {
                _dcBlab.Open();
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }

        public void Close() {
            _dcBlab.Close();
        }

        public void Create(IEntity obj) {
            Blab blab = (Blab) obj;
            try {
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sql =  "INSERT INTO blabs "
                           +  "(sys_id, message, dttm_created, user_id) "
                           +  "VALUES "
                           + $"('{blab.Id}', '{blab.Message}', '{now}', '{blab.User.Email}')";
                MySqlCommand cmd = new MySqlCommand(sql, _dcBlab);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }
        
        public IEnumerable ReadAll() {
            try {
                string sql = "SELECT * FROM blabs";
                MySqlDataAdapter daBlabs = new MySqlDataAdapter(sql, _dcBlab);
                MySqlCommandBuilder cbBlabs = new MySqlCommandBuilder(daBlabs);
                DataSet dsBlabs = new DataSet();
                daBlabs.Fill(dsBlabs);
                ArrayList alBlabs = new ArrayList();
                foreach (DataRow row in dsBlabs.Tables[0].Rows) alBlabs.Add(DataRow2Blab(row) );
                
                return alBlabs;
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }
        
        public IEntity ReadById(Guid id) {
            try {
                string sql = $"SELECT * FROM blabs WHERE blabs.sys_id = '{id.ToString() }'";
                MySqlDataAdapter daBlab = new MySqlDataAdapter(sql, _dcBlab);
                MySqlCommandBuilder cbBlab = new MySqlCommandBuilder(daBlab);
                DataSet dsBlab = new DataSet();
                daBlab.Fill(dsBlab, "blabs");
                DataRow row = dsBlab.Tables[0].Rows[0];
                
                return DataRow2Blab(row);
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }

        public IEnumerable ReadByUserId(string email) {
            try {
                string sql = $"SELECT * FROM blabs WHERE blabs.user_id = '{email.ToString() }'";
                MySqlDataAdapter daBlabs = new MySqlDataAdapter(sql, _dcBlab);
                MySqlCommandBuilder cbBlabs = new MySqlCommandBuilder(daBlabs);
                DataSet dsBlabs = new DataSet();
                daBlabs.Fill(dsBlabs);
                ArrayList alBlabs = new ArrayList();
                foreach (DataRow row in dsBlabs.Tables[0].Rows) alBlabs.Add(DataRow2Blab(row) );

                return alBlabs;
            } catch (Exception e) {
                throw new Exception(e.ToString() );
            }
        }

        public void Update(IEntity obj) {
            Blab blab = (Blab) obj;
        }

        public void Delete(IEntity obj) {
            Blab blab = (Blab) obj;
            string sql = $"DELETE FROM blabs WHERE blabs.sys_id = '{blab.Id}'";
            MySqlCommand cmd = new MySqlCommand(sql, _dcBlab);
            cmd.ExecuteNonQuery();
        }

        private Blab DataRow2Blab(DataRow row)
        {
            Blab blab = new Blab();

            blab.Id = new Guid(row["sys_id"].ToString());
            blab.Message = row["message"].ToString();
            blab.DTTM = (DateTime) row["dttm_created"];
            blab.User = (User) new MySqlUser().ReadByUserEmail(row["user_id"].ToString() );

            return blab;
        }
    }
}