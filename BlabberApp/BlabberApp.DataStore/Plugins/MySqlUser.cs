using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Interfaces;
using BlabberApp.Domain.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

namespace BlabberApp.DataStore.Plugins {
    public class MySqlUser : IUserPlugin {
        private MySqlConnection _dcUser;

        public MySqlUser() {
            _dcUser = new MySqlConnection("server=142.93.114.73;database=bubbafett1936;user=bubbafett1936;password=5h03b46Z23o5");
            try {
                _dcUser.Open();
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }

        public void Close() {
            _dcUser.Close();
        }

        public void Create(IEntity obj) {
            User user = (User) obj;
            try {
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sql_find = "SELECT email FROM users WHERE users.email = "
                               + $"'{user.Email}'";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql_find, _dcUser);
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();
                daUser.Fill(dsUser, "users");
                if (dsUser.Tables[0].Rows.Count > 0)
                    throw new DuplicateNameException("already registered");
                string sql =  "INSERT INTO users "
                           +  "(sys_id, email, dttm_registration, dttm_last_login) "
                           +  "VALUES "
                           + $"('{user.Id}', '{user.Email}', '{now}', '{now}')";
                MySqlCommand cmd = new MySqlCommand(sql, _dcUser);
                cmd.ExecuteNonQuery();
            } catch (DuplicateNameException dne) {
                throw new DuplicateNameException(dne.Message);
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }

        public IEnumerable ReadAll() {
            try {
                string sql = "SELECT * FROM users";
                MySqlDataAdapter daUsers = new MySqlDataAdapter(sql, _dcUser);
                MySqlCommandBuilder cbUsers = new MySqlCommandBuilder(daUsers);
                DataSet dsUsers = new DataSet();
                daUsers.Fill(dsUsers, "users");
                ArrayList alUsers = new ArrayList();
                foreach (DataRow row in dsUsers.Tables[0].Rows) alUsers.Add(DataRow2User(row) );
                return alUsers;
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }

        public IEntity ReadById(Guid id) {
            try {
                string sql = $"SELECT * FROM users WHERE users.sys_id = '{id.ToString() }'";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, _dcUser);
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();
                daUser.Fill(dsUser, "users");
                DataRow row = dsUser.Tables[0].Rows[0];
                User user = new User();
                user.Id = new Guid(row["sys_id"].ToString() );
                user.Email = row["email"].ToString();
                user.RegisterDTTM = (DateTime) row["dttm_registration"];
                user.LastLoginDTTM = (DateTime) row["dttm_last_login"];
                return user;
            } catch (Exception ex) {
                throw new Exception(ex.ToString() );
            }
        }

        public IEntity ReadByUserEmail(string id) {
            try {
                string sql = $"SELECT * FROM users WHERE users.email = '{id.ToString() }'";
                MySqlDataAdapter daUser = new MySqlDataAdapter(sql, _dcUser);
                MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
                DataSet dsUser = new DataSet();
                daUser.Fill(dsUser, "users");
                if (dsUser.Tables[0].Rows.Count < 1)
                    throw new DataException($"User {id} not found");
                DataRow row = dsUser.Tables[0].Rows[0];
                User user = new User();
                user.Id = new Guid(row["sys_id"].ToString());
                user.Email = row["email"].ToString();
                user.RegisterDTTM = (DateTime)row["dttm_registration"];
                user.LastLoginDTTM = (DateTime)row["dttm_last_login"];

                return user;
            } catch (DataException de) {
                throw new DataException(de.Message);
            } catch (Exception ex) {
                throw new Exception(ex.ToString());
            }
        }

        public void Update(IEntity obj) {
            User user = (User) obj;
        }

        public void Delete(IEntity obj) {
            User user = (User) obj;
            string sql = $"DELETE FROM users WHERE users.sys_id = '{user.Id}'";
            MySqlCommand cmd = new MySqlCommand(sql, _dcUser);
            cmd.ExecuteNonQuery();
        }

        private User DataRow2User(DataRow row)
        {
            User user = new User();

            user.Id = new Guid(row["sys_id"].ToString());
            user.Email = row["email"].ToString();
            user.RegisterDTTM = (DateTime)row["dttm_registration"];
            user.LastLoginDTTM = (DateTime)row["dttm_last_login"];

            return user;
        }
    }
}