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
                    string patientIdentifier = Guid.NewGuid().ToString();
                    foreach(Mutation m in list)
                    {
                        command = GetCommand();
                        command.CommandText = "SetMutation";
                        command.Parameters.Add(new SqlParameter("@PatientId", patientIdentifier ));
                        command.Parameters.Add(new SqlParameter("@Gene", m.Gene ));
                        command.Parameters.Add(new SqlParameter("@GeneSequenceLocator", m.Transscript )); 
                        command.Parameters.Add(new SqlParameter("@cDNAReference", m.CDSMutation.Identifier  ));
                        command.Parameters.Add(new SqlParameter("@MCPosition", m.MC1Position ));
                        command.Parameters.Add(new SqlParameter("@PreviousCodon", m.PreviousCodon  ));
                        command.Parameters.Add(new SqlParameter("@MutatedCodon", m.MutatedCodon   ));
                        command.Parameters.Add(new SqlParameter("@NextCodon", m.NextCodon   ));
                        command.Parameters.Add(new SqlParameter("@WT", m.CDSMutation.WT  ));
                        command.Parameters.Add(new SqlParameter("@Mut", m.CDSMutation.Mut )); 
                        command.Parameters.Add(new SqlParameter("@WA_", m.CDSMutation.WA_ ));
                        command.Parameters.Add(new SqlParameter("@_CG",m.CDSMutation._CG  ));
                        command.Parameters.Add(new SqlParameter("@CG_", m.CDSMutation.CG_    ));
                        command.Parameters.Add(new SqlParameter("@_GYW",m.CDSMutation._GYW  ));
                        command.Parameters.Add(new SqlParameter("@WRC_", m.CDSMutation.WRC_ ));
                        command.ExecuteNonQuery(); 
                        command.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //return false;
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
