using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HealthHack.TiSM.Model;
using System.Data.SqlClient; 

namespace HealthHack.TiSM.DAL
{
    public class MutationManager:Base
    {

        public bool PersistMutationList(List<Mutation> list)
        {
            
            SqlConnection con = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                using (con = GetConnection())
                {
                    con.Open();
                    foreach(Mutation m in list)
                    {
                        command = GetCommand();
                        command.CommandText = "SetMutation";
                        command.Parameters.Add(new SqlParameter("@Gene", m.Gene ));
                        command.Parameters.Add(new SqlParameter("@GeneSequenceLocator", m.Transscript )); 
                        command.Parameters.Add(new SqlParameter("@cDNAReference", m.CDSMutation.Identifier  ));
                        command.Parameters.Add(new SqlParameter("@MCPosition", m.CDSMutation.Position));
                        command.Parameters.Add(new SqlParameter("@PreviousCodon", m.PreviousCodon  ));
                        command.Parameters.Add(new SqlParameter("@MutatedCodon", m.MutatedCodon   ));
                        command.Parameters.Add(new SqlParameter("@NextCodon", m.NextCodon   ));
                        command.ExecuteNonQuery(); 
                        command.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (con != null && con.State != System.Data.ConnectionState.Closed)
                {
                    con.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
            }

            return true;
        }
    }
}
