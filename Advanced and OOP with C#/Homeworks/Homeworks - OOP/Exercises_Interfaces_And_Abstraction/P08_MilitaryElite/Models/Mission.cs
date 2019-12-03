using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Exeptions;
using System;

namespace P08_MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.ParseState(state);
        }
        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (State == State.Finished)
            {
                throw new InvalidMissionCompletionExeption();
            }

            this.State = State.Finished;
        }

        private void ParseState(string stateStr)
        {
            State state;

            bool parsed = Enum.TryParse<State>(stateStr, out state);

            if (!parsed)
            {
                throw new InvalidStateExeption();
            }

            this.State = state;
        }
    }
}
