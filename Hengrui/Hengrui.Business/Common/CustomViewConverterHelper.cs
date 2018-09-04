using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hengrui.DataAccess.Models.Projects;

namespace Hengrui.Business.Common
{
    public static class CustomViewConverterHelper
    {
        private const string ProjectTypeString = "project:";
        private const string ContractTypeString = "contract:";
        private const string PaperTypeString = "paper:";
        private const string DocumentationTypeString = "documentation:";

        public static bool FilterProjectByState(IProject p, string condition)
        {
            var stateCriteria = GetStateCriteria(condition);
            bool filter = true;
            string state = string.Empty;
            switch (stateCriteria.Type)
            {
                case StateType.Project:
                    state = p.CurrentProjectState.Status.ToString();
                    filter &= Filter(state, stateCriteria);
                    break;
                case StateType.Contract:
                    state = p.CurrentContractState.Status.ToString();
                    filter &= Filter(state, stateCriteria);
                    break;
            }

            return filter;
        }

        static bool Filter(string state, StateCriteria stateCriteria)
        {
            bool filter = false;
            int j = 0;
            for (int i = 0; i < stateCriteria.Criteria.Values.Count; i++)
            {
                if (i == 0)
                {
                    filter = state.Equals(stateCriteria.Criteria.Values[i]);
                }
                else
                {
                    if (stateCriteria.Criteria.Operators[j] == Operator.Or)
                    {
                        filter |= state.Equals(stateCriteria.Criteria.Values[i]);
                    }
                    else
                    {
                        filter &= state.Equals(stateCriteria.Criteria.Values[i]);
                    }
                    j++;
                }
            }

            return filter;
        }


        public static StateCriteria GetStateCriteria(this string filter)
        {
            string criteria;
            var type = GetStateType(filter, out criteria);
            var criteriaList = GetCriteria(criteria);
            return new StateCriteria { Criteria = criteriaList, Type = type };
        }

        static StateType GetStateType(string filter, out string criteria)
        {
            criteria = filter;
            if (criteria.ToLower().StartsWith(ProjectTypeString))
            {
                criteria = criteria.Replace(ProjectTypeString, "");
                return StateType.Project;
            }
            if (criteria.ToLower().StartsWith(ContractTypeString))
            {
                criteria = criteria.Replace(ContractTypeString, "");
                return StateType.Contract;
            }
            if (criteria.ToLower().StartsWith(PaperTypeString))
            {
                criteria = criteria.Replace(PaperTypeString, "");
                return StateType.Paper;
            }
            if (criteria.ToLower().StartsWith(DocumentationTypeString))
            {
                criteria = criteria.Replace(DocumentationTypeString, "");
                return StateType.Documentation;
            }

            return StateType.None;
        }

        public static Criteria GetCriteria(this string filter)
        {
            var criteria = new Criteria();
            var items = ExtractWords(filter);
            for (int i = 0; i < items.Count; i++)
            {
                if (i % 2 != 0)
                {
                    criteria.Operators.Add(ConvertOperator(items[i]));
                }
                else
                {
                    criteria.Values.Add(items[i]);
                }
            }

            return criteria;
        }

        static List<string> ExtractWords(string item)
        {
            var items = item.ToCharArray();
            var list = new List<string>();
            var value = string.Empty;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == ' ')
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        list.Add(value);
                        value = string.Empty;
                    }
                }
                else
                {
                    value += item[i];
                }
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                list.Add(value);
            }
            return list;
        }

        public class StateCriteria
        {
            public StateType Type { get; set; }

            public Criteria Criteria { get; set; }
        }

        public enum StateType
        {
            Project, Contract, Paper, Documentation, None
        }


        public class Criteria
        {
            public Criteria()
            {
                Values = new List<string>();
                Operators = new List<Operator>();
            }

            public List<string> Values { get; set; }

            public List<Operator> Operators { get; set; }
        }

        public class StateCriteria
        {
            public StateType Type { get; set; }

            public string Value { get; set; }
        }

        public enum Operator
        {
            Or,
            And
        }

        public static Operator ConvertOperator(string op)
        {
            switch (op.ToLower())
            {
                case "and":
                    return Operator.And;
                default:
                    return Operator.Or;
            }
        }
    }
}
