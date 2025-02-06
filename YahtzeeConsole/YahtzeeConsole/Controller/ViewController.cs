using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahtzeeConsole.View;

namespace YahtzeeConsole.Controller
{
    public class ViewController
    {
        public static void run()
        {
            do 
            {
                int selection = YahtzeeUI.MenuSelection();
                GameController gameController = new GameController();
                switch (selection)
                {
                    case 1:
                        gameController.startGame(1);
                        break;
                    case 2:
                        int numPlayersOption = YahtzeeUI.NumberOfPlayersSelection();
                        switch (numPlayersOption)
                        {
                            case 1:
                                gameController.startGame(2);
                                break;
                            case 2:
                                gameController.startGame(3);
                                break;
                            case 3:
                                gameController.startGame(4);
                                break;
                            case 4:
                                gameController.startGame(5);
                                break;
                            case 5:
                                gameController.startGame(6);
                                break;
                        }
                        break;
                    case 3:
                        YahtzeeUI.HowToPlay();
                        break;
                    case 4:
                        YahtzeeUI.ScoringRules();
                        break;
                    case 5:
                        return;
                }
            } while (true);
        }
    }
}
