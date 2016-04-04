using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTournament
{
    public class Tournament
    {

        #region FIELDS

        private List<Competitor> _competitors;

        private int _unseededLevels;

        private int _groupsToMake;

        private List<Group> _groups;

        private bool sortDescending = true;

        private Random rnd;

        #endregion


        #region PROPERTIES

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

        public int UnseededLevels
        {
            get
            {
                return _unseededLevels;
            }

            set
            {
                _unseededLevels = value;
            }
        }

        public int GroupsToMake
        {
            get
            {
                return _groupsToMake;
            }

            set
            {
                _groupsToMake = value;
            }
        }

        protected List<Group> Groups
        {
            get
            {
                return _groups;
            }

            set
            {
                _groups = value;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public Tournament()
        {
            _competitors = new List<Competitor>();
            _groups = new List<Group>();
            rnd = new Random();
        }

        #endregion

        #region PUBLIC METHODS

        public int MakeBalancedGroups()
        {
            int result = 0;
            List<Competitor> competitorsTempList;
            List<Competitor> competitorsTopList;
            Competitor dequeuedCompetitor;
            int mostWeakGroup;

            MakeGroups();
            competitorsTempList = SortCompetitors();

            for (int i = 0; i < _unseededLevels; i++)
            {
                competitorsTopList = getTopCompetitors(_groupsToMake, competitorsTempList);
                for (int j = 0; j < _groupsToMake; j++)
                {
                    dequeuedCompetitor = dequeueRandomCompetitor(competitorsTopList);
                    _groups[j].Competitors.Add(dequeuedCompetitor);
                }
            } 


            while(competitorsTempList.Count > 0)
            {
                dequeuedCompetitor = dequeueRandomCompetitor(competitorsTempList);
                mostWeakGroup = getMostWeakGroup();
                _groups[mostWeakGroup].Competitors.Add(dequeuedCompetitor);
            }
            

            return result;
        }

        private int getMostWeakGroup()
        {
            int result = 0;
            float weakestGroupWeight = Int32.MaxValue;
            float actualGroupWeight = 0;

            for(int i=0; i<_groups.Count; i++)
            {
                actualGroupWeight = _groups[i].getWeight();
                if (actualGroupWeight <= weakestGroupWeight)
                {
                    result = i;
                    weakestGroupWeight = actualGroupWeight;
                }
            }

            return result;
        }

        private Competitor dequeueRandomCompetitor(List<Competitor> competitorsTopList)
        {
            Competitor result;
            int count = competitorsTopList.Count;
            int pick = rnd.Next(0, count);

            result = competitorsTopList.ElementAt(pick);
            competitorsTopList.RemoveAt(pick);

            return result;
        }

        private List<Competitor> getTopCompetitors(int _groupsToMake, List<Competitor> competitorsTempList)
        {
            List<Competitor> result;

            result = new List<Competitor>();

            for(int i=0; i < _groupsToMake; i++)
            {
                result.Add(competitorsTempList.First());
                competitorsTempList.RemoveAt(0);
            }


            return result;
        }

        private void MakeGroups()
        {
            _groups = new List<Group>();
            for(int i=1; i<= _groupsToMake; i++)
            {
                _groups.Add(new Group(i.ToString()));
            }
        }

        private List<Competitor> SortCompetitors()
        {
            return _competitors.OrderByDescending(p => p.Elo).ToList();
        }

        #endregion
    }
}
