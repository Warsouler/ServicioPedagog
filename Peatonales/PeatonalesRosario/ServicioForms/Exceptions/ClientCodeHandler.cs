using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exceptions
{
    public class ClientCodeHandler
    {
        private static ClientCodeHandler _handler;
        private ClientCodeHandler() { }

        private ClientCodeHandler ExceptionHandler;

        private Dictionary<int, string> codeExceptions;

        public Dictionary<int, string> CodeExceptions
        {
            get
            {
                if (codeExceptions == null)
                    FillCodeExceptions();
                return codeExceptions;
            }

            set
            {
                codeExceptions = value;
            }
        }

        public static ClientCodeHandler GetInstance()
        {
            if (_handler == null)
                _handler = new ClientCodeHandler();
            return _handler;
        }

        private void FillCodeExceptions()
        {
            codeExceptions = new Dictionary<int,string>();
            #region Juan 1 to 10000 
            codeExceptions.Add(0005, "txtname");
            

















































            #endregion

            #region Develop1 = Nahuel 10001 20000
            //115
            codeExceptions.Add(10001, "Name");
            codeExceptions.Add(10002, "name");
            codeExceptions.Add(10003, "description");
            codeExceptions.Add(10004, "name");
            codeExceptions.Add(10005, "");
            codeExceptions.Add(10006, "");
            codeExceptions.Add(10007, "");
            codeExceptions.Add(10008, "");
            codeExceptions.Add(10009, "");
            codeExceptions.Add(10010, "");
            codeExceptions.Add(10011, "");
            codeExceptions.Add(10012, "");
            codeExceptions.Add(10013, "");
            codeExceptions.Add(10014, "");
            codeExceptions.Add(10015, "");
            codeExceptions.Add(10016, "");
            codeExceptions.Add(10017, "");
            codeExceptions.Add(10018, "");
            codeExceptions.Add(10019, "prizecode");
            codeExceptions.Add(10020, "");
            codeExceptions.Add(10021, "");
            codeExceptions.Add(10022, "");
            codeExceptions.Add(10023, "");
            codeExceptions.Add(10024, "");
            codeExceptions.Add(10025, "");
            codeExceptions.Add(10026, "");
            codeExceptions.Add(10027, "");
            codeExceptions.Add(10028, "");
            codeExceptions.Add(10029, "");
            codeExceptions.Add(10030, "");













            //160
            #endregion

            #region Develop2 = Wilson Develop 20001 30000
            //164















































            //212
            #endregion

            #region Develop3 = Manu  30001 40000
            //216
            codeExceptions.Add(30001, ""); codeExceptions.Add(30002, ""); codeExceptions.Add(30003, ""); codeExceptions.Add(30004, ""); codeExceptions.Add(30005, "");
            codeExceptions.Add(30006, ""); codeExceptions.Add(30007, ""); codeExceptions.Add(30008, ""); codeExceptions.Add(30009, ""); codeExceptions.Add(30010, "");
            codeExceptions.Add(30011, ""); codeExceptions.Add(30012, ""); codeExceptions.Add(30013, ""); codeExceptions.Add(30014, ""); codeExceptions.Add(30015, "");
            codeExceptions.Add(30016, ""); codeExceptions.Add(30017, ""); codeExceptions.Add(30018, ""); codeExceptions.Add(30019, ""); codeExceptions.Add(30020, "");
            codeExceptions.Add(30021, ""); codeExceptions.Add(30022, ""); codeExceptions.Add(30023, ""); codeExceptions.Add(30024, ""); codeExceptions.Add(30025, "");
            codeExceptions.Add(30026, ""); codeExceptions.Add(30027, ""); codeExceptions.Add(30028, ""); codeExceptions.Add(30029, ""); codeExceptions.Add(30030, "");
            codeExceptions.Add(30031, ""); codeExceptions.Add(30032, ""); codeExceptions.Add(30033, ""); codeExceptions.Add(30034, ""); codeExceptions.Add(30035, "");
            codeExceptions.Add(30036, ""); codeExceptions.Add(30037, ""); codeExceptions.Add(30038, ""); codeExceptions.Add(30039, ""); codeExceptions.Add(30040, "");
            codeExceptions.Add(30041, ""); codeExceptions.Add(30042, ""); codeExceptions.Add(30043, ""); codeExceptions.Add(30044, ""); codeExceptions.Add(30045, "");
            codeExceptions.Add(30046, ""); codeExceptions.Add(30047, ""); codeExceptions.Add(30048, ""); codeExceptions.Add(30049, ""); codeExceptions.Add(30050, "");
            codeExceptions.Add(30051, ""); codeExceptions.Add(30052, ""); codeExceptions.Add(30053, ""); codeExceptions.Add(30054, ""); codeExceptions.Add(30055, "");
            codeExceptions.Add(30056, ""); codeExceptions.Add(30057, ""); codeExceptions.Add(30058, ""); codeExceptions.Add(30059, ""); codeExceptions.Add(30060, "");














































            //275
            #endregion

            #region Develop4 = Pradel  40001 50000
            //278
            codeExceptions.Add(400019, "nomorelives");













































            //325
            #endregion

            #region Develop5 = Juli 50001 60000
            //329
            codeExceptions.Add(50001, ""); codeExceptions.Add(50002, ""); codeExceptions.Add(50003, ""); codeExceptions.Add(50004, ""); codeExceptions.Add(50005, ""); codeExceptions.Add(50006, ""); codeExceptions.Add(50007, ""); codeExceptions.Add(50008, ""); codeExceptions.Add(50009, ""); codeExceptions.Add(50010, ""); codeExceptions.Add(50011, ""); codeExceptions.Add(50012, ""); codeExceptions.Add(50013, ""); codeExceptions.Add(50014, ""); codeExceptions.Add(50015, ""); codeExceptions.Add(50016, ""); codeExceptions.Add(50017, ""); codeExceptions.Add(50018, ""); codeExceptions.Add(50019, ""); codeExceptions.Add(50020, ""); codeExceptions.Add(50021, ""); codeExceptions.Add(50022, ""); codeExceptions.Add(50023, ""); codeExceptions.Add(50024, ""); codeExceptions.Add(50025, ""); codeExceptions.Add(50026, ""); codeExceptions.Add(50027, ""); codeExceptions.Add(50028, ""); codeExceptions.Add(50029, ""); codeExceptions.Add(50030, ""); codeExceptions.Add(50031, ""); codeExceptions.Add(50032, ""); codeExceptions.Add(50033, ""); codeExceptions.Add(50034, ""); codeExceptions.Add(50035, ""); codeExceptions.Add(50036, ""); codeExceptions.Add(50037, ""); codeExceptions.Add(50038, ""); codeExceptions.Add(50039, ""); codeExceptions.Add(50040, ""); codeExceptions.Add(50041, ""); codeExceptions.Add(50042, ""); codeExceptions.Add(50043, "");













































            
            //377
            #endregion
        }

    }
}