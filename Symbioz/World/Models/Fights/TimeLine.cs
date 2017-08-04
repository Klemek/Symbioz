using Symbioz.World.Models.Fights.Fighters;
using System.Collections.Generic;
using System.Linq;

namespace Symbioz.World.Models.Fights
{
    public class TimeLine
    {
        public delegate void NewRoundDelegate(uint round);
        public event NewRoundDelegate OnNewRound;
        public int memory = 0;

        internal List<Fighter> m_fighters = new List<Fighter>();

        internal uint m_round = 1;

        internal int m_currentIndex = 0;

        public void Add(Fighter fighter)
        {
            m_fighters.Add(fighter);
            Sort();
        }
        public void Insert(Fighter inserted, Fighter master)
        {
            int index = m_fighters.IndexOf(master);
            m_fighters.Insert(index + 1, inserted);
        }
        public void Sort()
        {
            if (memory == m_fighters.Count)
            {
                List<Fighter> m_fighters_1 = new List<Fighter>();
                List<Fighter> m_fighters_2 = new List<Fighter>();

                for (int i = 0; i < m_fighters.Count; i++)
                {
                    if (m_fighters[i].Team.TeamColor == TeamColorEnum.BLUE_TEAM)
                    {
                        m_fighters_1.Add(m_fighters[i]);
                    }
                }
                for (int i = 0; i < m_fighters.Count; i++)
                {
                    if (m_fighters[i].Team.TeamColor == TeamColorEnum.RED_TEAM)
                    {
                        m_fighters_2.Add(m_fighters[i]);
                    }
                }

                m_fighters_1 = m_fighters_1.OrderByDescending(x => x.GetInitiative()).ToList();
                m_fighters_2 = m_fighters_2.OrderByDescending(x => x.GetInitiative()).ToList();
                int aux = 0;
                int aux1 = 0;
                int aux2 = 0;
                int num1;
                int num2;

                if (m_fighters_1[0].GetInitiative() > m_fighters_2[0].GetInitiative())
                {
                    num1 = 0;
                    num2 = 1;
                }
                else
                {
                    num1 = 1;
                    num2 = 0;
                }

                for (int i = 0; i < m_fighters.Count ; i++)
                {
                    if ((i % 2 == num1) && (aux1 < m_fighters_1.Count))
                    {
                        m_fighters[aux] = m_fighters_1[aux1];
                        aux++;
                        aux1++;
                    }
                    if ((i % 2 == num2) && (aux2 < m_fighters_2.Count))
                    {
                        m_fighters[aux] = m_fighters_2[aux2];
                        aux++;
                        aux2++;
                    }
                }
            }
            else
            {
                m_fighters = m_fighters.OrderByDescending(x => x.GetInitiative()).ToList();
            }
            memory = m_fighters.Count;
            
        }
        public Fighter GetPlayingFighter()
        {
            if (m_currentIndex >= 0)
                return m_fighters[m_currentIndex];
            else
            {
                if (m_fighters.Count > 0)
                    return m_fighters[0];
                else
                    return null;
            }
        }
        public void StartFight()
        {
            OnNewRound(m_round);
        }
        public Fighter GetFirstFighter()
        {
            return m_fighters[0];
        }
        public void RemoveFighter(Fighter fighter)
        {
            var removed = m_fighters.Find(x => x == fighter);
            if (removed == null)
                return;
            int num = this.m_fighters.IndexOf(fighter);
            m_fighters.Remove(fighter);
            if (num <= m_currentIndex)
            {
                this.m_currentIndex--;
            }

        }
        public Fighter PopNextFighter()
        {
            m_currentIndex++;
            if (m_currentIndex == m_fighters.Count())
            {
                m_round++;
                if (OnNewRound != null)
                    OnNewRound(m_round);
                m_currentIndex = 0;
            }
            if (m_currentIndex == -1)
                m_currentIndex++;

            return m_fighters[m_currentIndex];
        }
        public int[] GenerateTimeLine(bool sort = true)
        {
            if (sort)
                Sort();
            return m_fighters.ConvertAll<int>(x => x.ContextualId).ToArray();
        }

    }
}
