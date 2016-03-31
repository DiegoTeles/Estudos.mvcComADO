using Estudos.MvcComADO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Estudos.mvcComADO.Controllers;

namespace Estudos.mvcComADO.Repository
{
    public class TimeRepository
    {
        private SqlConnection _con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(constr);
        }

        //Adicionar Time
        public bool AdicionarTime(Times timeObj)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DS_NOMES", timeObj.Time);
                command.Parameters.AddWithValue("@DS_ESTADO", timeObj.Estado);
                command.Parameters.AddWithValue("@CORES", timeObj.Cores);

                _con.Open();
                i = command.ExecuteNonQuery();
            }
            _con.Close();
            return i >= 1;
        }

        //Obter Todos os Times
        public List<Times> ObterTimes()
        {
            Connection();
            List<Times> timeslist = new List<Times>();

            using (SqlCommand command = new SqlCommand("ObterTimes", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Times time = new Times()
                    {
                        ID_Time = Convert.ToInt32(reader["ID_Time"]),
                        Time = Convert.ToString(reader["DS_NOMES"]),
                        Estado = Convert.ToString(reader["DS_ESTADO"]),
                        Cores = Convert.ToString(reader["CORES"])
                    };
                    timeslist.Add(time);
                }

                _con.Close();
                return timeslist;
            }
        }

        //Atualizar Time
        public bool AtualizarTime(Times timeObj)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID_TIME", timeObj.ID_Time);
                command.Parameters.AddWithValue("@DS_NOMES", timeObj.Time);
                command.Parameters.AddWithValue("@DS_ESTADO", timeObj.Estado);
                command.Parameters.AddWithValue("@CORES", timeObj.Cores);

                _con.Open();
                i = command.ExecuteNonQuery();
            }
            _con.Close();
            return i >= 1;
        }

        //Excluir Time
        public bool ExcluirTime(int id)
        {

            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirTimePorId", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID_TIME", id);
               
                _con.Open();
                i = command.ExecuteNonQuery();
            }
            _con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}