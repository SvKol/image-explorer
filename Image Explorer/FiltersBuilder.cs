using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Image_Explorer
{
    public class FiltersBuilder
    {
        private interface ICondition
        {
            public int type { get; set; }
            public bool Evaluate(ImageData image);
        }

        private class Brackets : ICondition
        {
            private List<ICondition> conditions = new List<ICondition>();

            public int Size { get { return conditions.Count; } }

            public void AddCondition(ICondition cond)
            {
                for (int i = 0; i < conditions.Count; i++)
                {
                    if (conditions[i].Equals(cond))
                    {
                        conditions[i] = cond;
                        return;
                    }
                }
                conditions.Add(cond);
            }

            public void RemoveCondition(ICondition cond)
            {
                for(int i = 0; i < conditions.Count; i++)
                {
                    if (conditions[i].Equals(cond))
                    {
                        conditions.RemoveAt(i);
                        return;
                    }
                }
            }

            public int type { get; set; }

            public bool Evaluate(ImageData image)
            {
                bool result = true;
                for (int i = 0; i < conditions.Count; i++)
                {
                    if (conditions[i].type > 0 && i > 0)
                        result |= conditions[i].Evaluate(image);
                    else
                        result &= conditions[i].Evaluate(image);
                }
                return type < 0 ^ result;
            }

            public Brackets(int type) => this.type = type;

            public void Clear() => conditions.Clear();

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("(");
                bool first = true;
                foreach(ICondition cond in conditions)
                {
                    if (first) {
                        first = false;
                        if (cond.type < 0)
                            sb.Append("NOT ");
                    }
                    else
                    {
                        if (cond.type < 0)
                            sb.Append(" AND NOT ");
                        else if (cond.type > 0)
                            sb.Append(" OR ");
                        else
                            sb.Append(" AND ");
                    }
                    sb.Append(cond.ToString());
                }
                sb.Append(")");
                return sb.ToString();
            }

            public Dictionary<string, int> GetLevelFilters()
            {
                Dictionary<string, int> levelFilters = new Dictionary<string, int>();
                foreach(ICondition iCond in conditions)
                {
                    Condition cond = iCond as Condition;
                    if(cond != null)
                        levelFilters.Add(cond.tag, cond.type);
                }
                return levelFilters;
            }
        }

        private class Condition : ICondition
        {
            private string _tag;

            public int type { get; set; }

            public string tag { get { return _tag; } }

            public bool Evaluate(ImageData image)
            {
                if (String.IsNullOrEmpty(_tag))
                    return type < 0 ^ image.keywords.Count == 0;
                return type < 0 ^ image.keywords.Contains(_tag);
                // type = -1 (not) && image contains tag => false
                // type = 0|1 (and/or) && image contains tag => true
                // type = -1 (not) && image doesn't contain tag => true
                // type = 0|1 (and/or) && image doesn't contain tag => false
            }

            public Condition(String tag, int type)
            {
                _tag = tag;
                this.type = type;
            }

            public override int GetHashCode() => base.GetHashCode();

            public override bool Equals(object? obj)
            {
                if (obj == null)
                    return false;
                Condition cond = obj as Condition;
                if (cond == null)
                    return false;
                if (cond == this)
                    return true;
                return cond._tag.Equals(_tag);
            }

            public override string ToString()
            {
                if (String.IsNullOrEmpty(_tag))
                    return "UNTAGGED";
                return _tag.ToUpper().Replace("_", " ");
            }
        }

        private Brackets conditions;
        private List<Brackets> active;

        public FiltersBuilder()
        {
            conditions = new Brackets(0);
            active = new List<Brackets>();
            active.Add(conditions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Brackets GetActive() => active.Last();

        public void GoIn(int type)
        {
            Brackets brackets = new Brackets(type);
            GetActive().AddCondition(brackets);
            active.Add(brackets);
        }

        public bool GoOut()
        {
            int pos = active.Count - 1;
            if (pos > 0)
            {
                if (active[pos].Size == 0)
                {
                    active[pos - 1].RemoveCondition(active[pos]);
                }
                active.RemoveAt(pos);
                return true;
            }
            return false;
        }

        public bool Evaluate(ImageData image) => conditions.Evaluate(image);

        public void Clear()
        {
            active.Clear();
            conditions.Clear();
            active.Add(conditions);
        }

        public void AddCondition(String tag, int type) => GetActive().AddCondition(new Condition(tag, type));

        public void RemoveCondition(String tag) => GetActive().RemoveCondition(new Condition(tag, 0));

        public override string ToString() => conditions.ToString();

        public Dictionary<string, int> GetCurrentLevelFilters()
        {
            return GetActive().GetLevelFilters();
        }
    }
}
