using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTournament
{
    public class Competitor
    {

        #region FIELDS

        private string _name;

        private float _elo;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public float Elo
        {
            get
            {
                return _elo;
            }

            set
            {
                _elo = value;
            }
        }
        
        #endregion


    }
}
