using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTournament
{
    public class Group
    {

        #region FIELDS

        private string _name;

        private List<Competitor> _competitors;

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

        public List<Competitor> Competitors
        {
            get
            {
                return _competitors;
            }

            set
            {
                _competitors = value;
            }
        }

        #endregion


        #region CONSTRUCTORS

        public Group()
        {
            this._name = "Unnamed";
            this._competitors = new List<Competitor>();
        }

        public Group(string name)
        {
            this._name = name;
            this._competitors = new List<Competitor>();
        }

        public float getWeight()
        {
            float result = 0;

            result = this._competitors.Sum(p => p.Elo);

            return result;
        }

        #endregion

    }
}
