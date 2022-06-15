using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logik_2
{
    public class game
    {
        public pin[] Pattern { get; set; }
        public List<attempt> Attempts { get; set; }
        public attempt ActualAttempt { get; set; }
        public GameState State { get; internal set; }

        public game()
        {
            Pattern = new pin[4];
            CreatePattern();
            Attempts = new List<attempt>();
            ActualAttempt = new attempt();
            State = GameState.Run;
        }
        private void CreatePattern()
        {
            Random random = new Random();
            int rndValue;
            for(int i = 0; i < 4; i++)
            {
                rndValue = random.Next(1, 7);
                Pattern[i] = new pin() { Color = PinColor.Color1 };
            }
            for (int i = 0; i < 4; i++)
            {
                rndValue = random.Next(1, 7);
                Pattern[i] = new pin() { Color = PinColor.Color2 };
            }
            for (int i = 0; i < 4; i++)
            {
                rndValue = random.Next(1, 7);
                Pattern[i] = new pin() { Color = PinColor.Color3 };
            }
            for (int i = 0; i < 4; i++)
            {
                rndValue = random.Next(1, 7);
                Pattern[i] = new pin() { Color = PinColor.Color4 };
            }
            for (int i = 0; i < 4; i++)
            {
                rndValue = random.Next(1, 7);
                Pattern[i] = new pin() { Color = PinColor.Color5 };
            }
            for (int i = 0; i < 4; i++)
            {
                rndValue = random.Next(1, 7);
                Pattern[i] = new pin() { Color = PinColor.Color6 };
            }
        }

        public void EvaluateActualAttempt()
        {
            if(State == GameState.Run)
            {
                var actualEvaluate = ActualAttempt.Evaluate(Pattern);
                if(actualEvaluate.FindAll(value => value == true).Count == 4)
                {
                    State = GameState.Win;
                }
                Attempts.Add(ActualAttempt);
                if(Attempts.Count >= 10)
                {
                    State = GameState.Loss;
                }
                ActualAttempt = new attempt();
            }
        }


    }

    public enum GameState
    {
        Win,
        Loss,
        Run
    }
}
