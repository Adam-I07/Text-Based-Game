using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Rpg_Game
{
    class RunGame
    {
        Character newCharacter = new Character();
        Random rand = new Random();
        public void StartGame()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string startGame = "yes";
            Console.WriteLine("Welcome to the minigame, The goal of the game is to get the most amount of money and highest health possible before the end.");
            Console.WriteLine("Press enter to start");
            Console.ReadKey();
            Console.WriteLine("What would you like to name your character: ");
            newCharacter._name = Console.ReadLine();
            newCharacter.Greeting();

            Console.WriteLine(newCharacter._name + " wakes up on a park bench confused getting up looking to go 'right' or 'left' where will you go?");
            string choice01 = Console.ReadLine().ToLower();
            do
            {
                if (choice01 == "right")
                {
                    right();
                    break;
                }

                else if (choice01 == "left")
                {

                    left();
                    break;
                }
                else
                {
                    Console.WriteLine("You cannot go in that direcion! Try again: ");
                    choice01 = Console.ReadLine().ToLower();
                }
            } while (startGame == "yes");
            Console.ReadKey();
        }


        void right()
        {
            Console.WriteLine("While " + newCharacter._name + " is walking he gets approched by a stranger who offers to flip a coin for £20");
            Console.WriteLine("Will you accept 'accept' or 'decline'");
            string userPlayHeadsOrTail = Console.ReadLine().ToLower();

            if (userPlayHeadsOrTail == "accept")
            {
                Console.WriteLine("The coin is thrown in the air, its your call 'heads' or 'tails'");
                string userHeadsOrTail = Console.ReadLine().ToLower();
                if (userHeadsOrTail == "heads")
                {
                    Console.WriteLine("The coin lands on heads congratulations you have won £20!!");
                    newCharacter.money_gained(20);
                    Console.WriteLine("You now have £" + newCharacter.bankBalance);
                    RightFoodProblem();
                }
                else if (userHeadsOrTail == "tails")
                {
                    Console.WriteLine("The coin lands on heads you have lost will you 'pay up' or 'not pay'");
                    string userPayorNot = Console.ReadLine().ToLower();

                    if (userPayorNot == "pay up")
                    {
                        newCharacter.money_lost(20);
                        newCharacter.stillHaveMoney();
                        Console.WriteLine("You decided to pay up for your loss and now your bank balance stands at £" + newCharacter.bankBalance);
                        RightFoodProblem();
                    }
                    else if (userPayorNot == "not pay")
                    {
                        Console.WriteLine("You stood your ground and refused to pay up");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your opponent got mad that you refused to pay him £20, he pulled out a knife and stabbed you!!");
                        newCharacter.damage(50);
                        newCharacter.stillAlive();
                        Console.WriteLine("The stab wounds have put your health down to " + newCharacter.health);
                        newCharacter.money_lost(50);
                        newCharacter.stillHaveMoney();
                        Console.WriteLine("While you are down your opponent robs £50 from your pocket");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        newCharacter.CheckStats();
                        RightFoodProblem();

                    }
                    else
                    {
                        Console.WriteLine("You started speaking gibberish, further angering the stranger");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The stranger follows through on his word stabbing you!! Robbing £50 from you! You lost 50 health");
                        newCharacter.damage(50);
                        newCharacter.money_lost(50);
                        newCharacter.stillHaveMoney();
                        newCharacter.stillAlive();
                        RightFoodProblem();
                    }
                }
                else
                {
            
                    Console.WriteLine("You started speaking gibberish, causing the stranger to tell you to get help and walk off");
                    RightFoodProblem();
                
                }
            }
            else if (userPlayHeadsOrTail == "decline")
            {
                Console.WriteLine("You refused the offer from the stranger and carried on your way.");
                RightFoodProblem();
            }
            else
            {
                Console.WriteLine("Your anxiety got the better of you, started talking giberish causing the stranger to walk away while staring you down.");
                RightFoodProblem();
            }

        }

        void left()
        {
            Console.WriteLine(newCharacter._name + " is walking when you are approched by a stranger who whispers give them £30 or they will stab you! Will you 'give money' or 'refuse'?");
            string choice03 = Console.ReadLine().ToLower();

            if (choice03 == "give money")
            {
                Console.WriteLine("You decided to give the stranger £30, he took the money and ran off");
                newCharacter.money_lost(30);
                newCharacter.stillHaveMoney();
                Console.WriteLine("The stranger ran away from you shouting that he didnt have any weapon calling you a loser");
                Console.WriteLine("In a sudden rush of anger you are decided whether to chase after the stanger and get your money back.");
                Console.WriteLine("Will you 'run after' the stranger to get your money back or 'forget about it'. THINK QUICK HES GETTING AWAY: ");
                string userStangerChoice = Console.ReadLine().ToLower();
                if (userStangerChoice == "run after")
                {
                    Console.WriteLine("You caught up to the stranger, grabbing them by their top and pinned them to the wall");
                    Console.WriteLine("Will you 'get £30' back that they took or 'return the favour' and rob them: ");
                    string userRevengeChoice = Convert.ToString(Console.ReadLine().ToLower());
                    if (userRevengeChoice == "get £30" || userRevengeChoice == "get 30")
                    {
                        Console.WriteLine("You lecture the stranger about stealing, while reaching into his pocket and getting your £30 back");
                        newCharacter.money_gained(30);
                        Console.WriteLine($"Your bank balance now stands at £{newCharacter.bankBalance}");
                        LeftWaterProblem();
                    }
                    else if (userRevengeChoice == "return the favour")
                    {
                        Console.WriteLine("You reach into the strangers pocket grabbing your £30 and his wallet");
                        Console.WriteLine("In his wallet you find £22 which you take and throw it at him while walking away");
                        newCharacter.money_gained(52);

                        Console.WriteLine($"Your bank balance now stands at £{newCharacter.bankBalance}");
                        LeftWaterProblem();

                    }
                    else
                    {
                        Console.WriteLine("You cant get your thoughts together in time, giving the stranger enough time to get away");
                        Console.WriteLine($"Your bank balance now stands at £{newCharacter.bankBalance}");
                        LeftWaterProblem();
                    }
                }
                else if ( userStangerChoice == "forget about it")
                {
                    Console.WriteLine("You couldnt be bothered to run after the stranger and accepted the loss.");
                    Console.WriteLine($"Your bank balance now stands at £{newCharacter.bankBalance}");
                    LeftWaterProblem();
                }
                else
                {
                    Console.WriteLine("You couldnt get your thoughts together in time and he got away with your money!");
                    Console.WriteLine($"Your bank balance now stands at £{newCharacter.bankBalance}");
                    LeftWaterProblem();
                }
            }
            else if (choice03 == "refuse")
            {
                Console.WriteLine("You told the stranger to get lost");
                Console.WriteLine("Your gut was correct the stranger made a meaningless threat and when push came to show he ran off");
                LeftWaterProblem();
            }
            else
            {
                Console.WriteLine("The stranger dosent hear what he wanted to he pushes you to the ground and run away");
                Console.WriteLine("You lost 10 health");
                newCharacter.damage(10);
                newCharacter.stillAlive();
                LeftWaterProblem();
            }
        }

        void LeftWaterProblem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You carry on walking for a while, you start feeling parched");
            Console.WriteLine("You look around for a source of water to re-hydrate yourself, You see a water vendor selling a bottle for £5, a public water fountain that look dirty or from the lake");
            Console.WriteLine("Will you 'buy water' or drink from the public 'water fountain' or from the dirty 'lake': ");
            string drinkChoice = Console.ReadLine().ToLower();

            if (drinkChoice == "buy water")
            {
                Console.WriteLine("You brought one bottle of water from the vendor for £5 and drank it instantly rehydrating yourself!");
                newCharacter.money_lost(5);
                newCharacter.stillHaveMoney();
                Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                string checkStats = Console.ReadLine().ToLower();
                if (checkStats == "y" || checkStats == "yes")
                {
                    newCharacter.CheckStats();
                    LeftPickUpGame();
                }
                else if (checkStats == "n" || checkStats == "no")
                {
                    LeftPickUpGame();
                }
                else
                {
                    LeftPickUpGame();
                }
            }
            else if (drinkChoice == "water fountain")
            {
                Console.WriteLine("You chose to drink from the public water fountain.");
                Console.WriteLine("The water fountain had a lot of bacteria on the tap causing you to lose 5 health!");
                Console.WriteLine("but you managed to hydrate yourself!");
                newCharacter.damage(5);
                Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                string checkStats = Console.ReadLine().ToLower();
                if (checkStats == "y" || checkStats == "yes")
                {
                    newCharacter.CheckStats();
                    LeftPickUpGame();
                }
                else if (checkStats == "n" || checkStats == "no")
                {
                    LeftPickUpGame();
                }
                else
                {
                    LeftPickUpGame();
                }
            }
            else if (drinkChoice == "lake")
            {
                Console.WriteLine("You chose to drink from the dirty lake");
                Console.WriteLine("The lake looked dirty and was contaminated causing you to lose 30 health");
                newCharacter.damage(30);
                newCharacter.stillAlive();
                LeftPickUpGame();
            }
            else
            {
                Console.WriteLine("You couldn't decide where to drink from! You lost 15 health due to de-hydration");
                newCharacter.damage(15);
                newCharacter.stillAlive();
                LeftPickUpGame();
            }
        }
        void RightFoodProblem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("After playing heads and tail you start feeling hungry.");
            Console.WriteLine("After looking around you see two options of getting food one is getting a hotdog from the food stand or eating a dead squirrel");
            Console.WriteLine("Will you get a hot dog from the 'food stand' or eat the 'roadkill'");
            string foodChoice = Console.ReadLine().ToLower();
            if (foodChoice == "food stand")
            {
                Console.WriteLine("You choose to buy a hot dog from the stand for £6.");
                newCharacter.money_lost(6);
                newCharacter.stillHaveMoney();
                Console.WriteLine("Would you like to put 'ketchup' on your hotdog for £2 or 'mustard' for £2 or 'both' for £4 or 'none'");
                string sauceChoice = Console.ReadLine().ToLower();
                if(sauceChoice == "ketchup")
                {
                    Console.WriteLine("You chose to put ketchup on the hotdog.");
                    newCharacter.money_lost(2);
                    newCharacter.stillHaveMoney();
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        rightCatchGame();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        rightCatchGame();
                    }
                    else
                    {
                        rightCatchGame();
                    }
                }
                else if( sauceChoice == "mustard")
                {
                    Console.WriteLine("You chose to put mustard on your hotdog.");
                    newCharacter.money_lost(2);
                    newCharacter.stillHaveMoney();
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        rightCatchGame();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        rightCatchGame();
                    }
                    else
                    {
                        rightCatchGame();
                    }
                }
                else if (sauceChoice == "both")
                {
                    Console.WriteLine("You chose to put ketchup and mustard on your hotdog costing you £4");
                    newCharacter.money_lost(4);
                    newCharacter.stillHaveMoney();
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        rightCatchGame();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        rightCatchGame();
                    }
                    else
                    {
                        rightCatchGame();
                    }
                }
                else if (sauceChoice == "none")
                {
                    Console.WriteLine("You chose to not put anything on your hotdog.");
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        rightCatchGame();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        rightCatchGame();
                    }
                    else
                    {
                        rightCatchGame();
                    }
                }
                else
                {
                    Console.WriteLine("You choose to not put anything on your hotdog.");
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        rightCatchGame();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        rightCatchGame();
                    }
                    else
                    {
                        rightCatchGame();
                    }
                }
            }
            else if (foodChoice == "roadkill")
            {
                Console.WriteLine("You picked up the dead squirell from the gound to eat");
                Console.WriteLine("Will you 'cook' the squirell or eat it 'raw'?");
                string cook = Console.ReadLine().ToLower();
                if (cook == "cook")
                {
                    Console.WriteLine("You chose to cook the squirell, eat it and it tasted ok..good enough to eat.");
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        rightCatchGame();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        rightCatchGame();
                    }
                    else
                    {
                        rightCatchGame();
                    }
                }
                else if (cook == "raw")
                {
                    Console.WriteLine("You ate the squirell raw and got food poisoning losing 50 health health");
                    newCharacter.damage(50);
                    newCharacter.stillAlive();
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        rightCatchGame();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        rightCatchGame();
                    }
                    else
                    {
                        rightCatchGame();
                    }
                }
            }
            else
            {
                Console.WriteLine("You couldnt decide what to eat and carried on losing 10 health.");
                newCharacter.damage(10);
                newCharacter.stillAlive();
                Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                string checkStats = Console.ReadLine().ToLower();
                if (checkStats == "y" || checkStats == "yes")
                {
                    newCharacter.CheckStats();
                    rightCatchGame();
                }
                else if (checkStats == "n" || checkStats == "no")
                {
                    rightCatchGame();
                }
                else
                {
                    rightCatchGame();
                }
            }
        }

        void LeftPickUpGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("After walking a while you get invited to join a park football match will you join? y (Yes) or n (No)");
            string userJoinGame = Console.ReadLine().ToLower();
            if (userJoinGame == "y" || userJoinGame == "yes")
            {
                Console.WriteLine("You accepted the invite and joined the game");
                Console.WriteLine("After a while of running around like a headless chicken you see the ball coming towards you");
                Console.WriteLine("The player is running at you at full speed will you choose to 'slide tackle' him or 'standing tackle' him");
                string userTackleChoice = Console.ReadLine().ToLower();
                if (userTackleChoice == "slide tackle")
                {
                    Console.WriteLine("You go in for the slide tackle....SUCCESSFULLY WINNING THE BALL!");
                    Console.WriteLine("You misjudge the concrete ground which grazes your leg losing 10 health points.");
                    newCharacter.damage(10);
                    newCharacter.stillAlive();
                    Console.WriteLine("A player comes up to you asks if your ok and want to keep on playing? 'y' (yes) or 'n' (no) ");
                    string userKeepGoing = Console.ReadLine().ToLower();
                    if (userKeepGoing == "y" || userKeepGoing == "yes")
                    {
                        Console.WriteLine("You assure your team mate you are fine to carry on while putting on a bandage");
                        Console.WriteLine("After joining back the game you find yourself at the top of the pitch with a cross coming in!");
                        Console.WriteLine("Will you keep it simple and 'tap in' the game for a winning goal, go for a 'bicycle kick' or a 'power shot': ");
                        string userKickChoice = Console.ReadLine().ToLower();
                        if (userKickChoice == "tap in")
                        {
                            Console.WriteLine("You chose to keep it simple and go for a tap in......YOU SCORED");
                            Console.WriteLine("Everyone congratulates you for scoring the winning game ansd called you the man of the match!!");
                            Console.WriteLine("You got informed the man of the match gets £5 congratulations");
                            newCharacter.money_gained(5);
                            LeftStrayAnimal();
                        }
                        else if (userKickChoice == "bicycle kick")
                        {
                            Console.WriteLine("You chose to go for a bicycle kick....YOU MISSED");
                            Console.WriteLine("Match over and your team lost!! Should have kept it simple.");
                            LeftStrayAnimal();

                        }
                        else if (userKickChoice == "power shot")
                        {
                            Console.WriteLine("You put all your power into the shot.....MISSEDD YOU SKIED IT");
                            Console.WriteLine("You managed to sky the shot losing the ball in the process and losing the match for your team");
                            Console.WriteLine("After feeling guilty will you give the ball owner £5 for a new ball: 'y' (yes) or 'n' (no)");
                            string payForNewBall = Console.ReadLine().ToLower();
                            if (payForNewBall == "y" || payForNewBall == "yes")
                            {
                                Console.WriteLine("You gave the owner of the ball £5 for a new ball, he said come back anytime to play again.");
                                newCharacter.money_lost(5);
                                newCharacter.stillHaveMoney();
                                LeftStrayAnimal();
                            }
                            else if(payForNewBall == "n" || payForNewBall == "no")
                            {
                                Console.WriteLine("You chose to not give the owner anything and just left!");
                                LeftStrayAnimal();
                            }
                            else
                            {
                                Console.WriteLine("You chose to not give the owner anything and just left!");
                                LeftStrayAnimal();
                            }
                        }
                    }
                }
                else if (userTackleChoice == "standing tackle")
                {
                    Console.WriteLine("You go for a standing tackle and you missed..bad choice the striker was stronger and outmsucled you throwing you to the gorund");
                    Console.WriteLine("You fall on to your elbow hurting yourself losing 10 points");
                    newCharacter.damage(10);
                    newCharacter.stillAlive();
                    Console.WriteLine("A player comes up to you asks if your ok and want to keep on playing? 'y' (yes) or 'n' (no) ");
                    string userKeepGoing = Console.ReadLine().ToLower();
                    if (userKeepGoing == "y" || userKeepGoing == "yes")
                    {
                        Console.WriteLine("You assure your team mate you are fine to carry on while putting on a bandage");
                        Console.WriteLine("After joining back the game you find yourself at the top of the pitch with a cross coming in!");
                        Console.WriteLine("Will you keep it simple and 'tap in' the game for a winning goal, go for a 'bicycle kick' or a 'power shot': ");
                        string userKickChoice = Console.ReadLine().ToLower();
                        if (userKickChoice == "tap in")
                        {
                            Console.WriteLine("You chose to keep it simple and go for a tap in......YOU SCORED");
                            Console.WriteLine("Everyone congratulates you for scoring the winning game ansd called you the man of the match!!");
                            Console.WriteLine("You got informed the man of the match gets £5 congratulations");
                            newCharacter.money_gained(5);
                            LeftStrayAnimal();
                        }
                        else if (userKickChoice == "bicycle kick")
                        {
                            Console.WriteLine("You chose to go for a bicycle kick....YOU MISSED");
                            Console.WriteLine("Match over and your team lost!! Should have kept it simple.");
                            LeftStrayAnimal();

                        }
                        else if (userKickChoice == "power shot")
                        {
                            Console.WriteLine("You put all your power into the shot.....MISSEDD YOU SKIED IT");
                            Console.WriteLine("You managed to sky the shot losing the ball in the process and losing the match for your team");
                            Console.WriteLine("After feeling guilty will you give the ball owner £5 for a new ball: 'y' (yes) or 'n' (no)");
                            string payForNewBall = Console.ReadLine().ToLower();
                            if (payForNewBall == "y" || payForNewBall == "yes")
                            {
                                Console.WriteLine("You gave the owner of the ball £5 for a new ball, he said come back anytime to play again.");
                                newCharacter.money_lost(5);
                                newCharacter.stillHaveMoney();
                                LeftStrayAnimal();
                            }
                            else if (payForNewBall == "n" || payForNewBall == "no")
                            {
                                Console.WriteLine("You chose to not give the owner anything and just left!");
                                LeftStrayAnimal();
                            }
                            else
                            {
                                Console.WriteLine("You chose to not give the owner anything and just left!");
                                LeftStrayAnimal();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You couldnt decide watching the man run by you without and resistance hearing groans from your team mates");
                    Console.WriteLine("Out of embarassment you grab all your items and leave as soon as possible");
                    LeftStrayAnimal();
                }
            }
            else if(userJoinGame == "n" || userJoinGame == "no")
            {
                Console.WriteLine("You thanked the stranger for the offer but decided to refuse.");
                LeftStrayAnimal();
            }
            else
            {
                Console.WriteLine("You couldnt make up your mind so you panicked and ran away");
                LeftStrayAnimal();
            }

        }

        void rightCatchGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You get approached by a stranger who says they need a 4th man in a catch game will you join? 'y' (yes) or 'n' (no)");
            string userJoinCatchGame = Console.ReadLine().ToLower();
            if (userJoinCatchGame == "y" || userJoinCatchGame == "yes")
            {
                Console.WriteLine("You accepted the offer and get ready to play");
                Console.WriteLine("Your first involvement is a high ball coming towards you, will you catch the ball with a straight forward 'two hands' pointed at the sky or go for the spectacular 'one handed' catch");
                string userCatchChoice = Console.ReadLine().ToLower();
                if(userCatchChoice == "two hands")
                {
                    Console.WriteLine("You go for the simple safe two handed catch...YOU CAUGHT THE BALL");
                    Console.WriteLine("Well done you caught the ball");
                    Console.WriteLine("Its your turn to throw the ball, this is the final play of the night you can win or lose it for your team now");
                    Console.WriteLine("Will you throw the ball at 'full power' or throw the ball as 'high' as you can in the air: ");
                    string finalThrow = Console.ReadLine().ToLower();
                    if (finalThrow == "full power")
                    {
                        Console.WriteLine("You threw the ball with all your power and the ball goes out of the area into the lake causing your team to lose!");
                        Console.WriteLine("The angered owner demands £10 as reimbursement! Will you 'reimburse' or 'refuse': ");
                        string userReinburseOrNot = Console.ReadLine().ToLower();
                        if (userReinburseOrNot == "reimburse")
                        {
                            Console.WriteLine("You applogised and gave the stanger £10 and left");
                            newCharacter.money_lost(10);
                            newCharacter.stillHaveMoney();
                            RightMoneyClip();
                        }
                        else if (userReinburseOrNot == "refuse")
                        {
                            Console.WriteLine("You told him to go away you aint giving him a penny");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The angered person punches you and kicks you when your down taking 40 of your health and takes £20");
                            newCharacter.money_lost(20);
                            newCharacter.damage(40);
                            newCharacter.stillHaveMoney();
                            newCharacter.stillAlive();
                            RightMoneyClip();
                        }
                        else
                        {
                            Console.WriteLine("You started mumbling not knowing what to say further angering the owner of the ball who thinks your wasting his time");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You get beaten up by the owner of the ball and his friends taking 50 of your health and each take £15 losing £60");
                            newCharacter.money_lost(60);
                            newCharacter.damage(50);
                            newCharacter.stillAlive();
                            newCharacter.stillHaveMoney();
                            RightMoneyClip();

                        }
                    }
                    else if(finalThrow == "high")
                    {
                        Console.WriteLine("You throw the ball as high as you can....THE OPPONENT DROPS THE BALL YOU WON");
                        Console.WriteLine("Everyone congratualtes you and tells you come back anytime to play again");
                        RightMoneyClip();
                    }
                    else
                    {
                        Console.WriteLine("You panicked under all the preassure and throw the ball 1 meter away from you");
                        Console.WriteLine("Everyone starts laughing at you out of embarrasement you run away losing confidence");
                        RightMoneyClip();
                    }
                }
                else if(userCatchChoice == "one handed")
                {
                    Console.WriteLine("You go for the glamorous one handed catch.....YOU MISSED");
                    Console.WriteLine("The ball hit your arm and bounced off injuring your arm losing 10 health");
                    newCharacter.damage(10);
                    newCharacter.stillAlive();
                    Console.WriteLine("You are asked if you are ok to go on? 'y' (yes) or 'n' (no) ");
                    string userCarryOn = Console.ReadLine().ToLower();
                    if (userCarryOn == "y" || userCarryOn == "yes")
                    {
                        Console.WriteLine("You assure everyone your fine to carry on");
                        Console.WriteLine("Its your turn to throw the ball, this is the final play of the night you can win or lose it for your team now");
                        Console.WriteLine("Will you throw the ball at 'full power' or throw the ball as 'high' as you can in the air: ");
                        string finalThrow = Console.ReadLine().ToLower();
                        if (finalThrow == "full power")
                        {
                            Console.WriteLine("You threw the ball with all your power and the ball goes out of the area into the lake causing your team to lose!");
                            Console.WriteLine("The angered owner demands £10 as reimbursement! Will you 'reimburse' or 'refuse': ");
                            string userReinburseOrNot = Console.ReadLine().ToLower();
                            if (userReinburseOrNot == "reimburse")
                            {
                                Console.WriteLine("You applogised and gave the stanger £10 and left");
                                newCharacter.money_lost(10);
                                newCharacter.stillHaveMoney();
                                RightMoneyClip();
                            }
                            else if (userReinburseOrNot == "refuse")
                            {
                                Console.WriteLine("You told him to go away you aint giving him a penny");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The angered person punches you and kicks you when your down taking 40 of your health and takes £20");
                                newCharacter.money_lost(20);
                                newCharacter.damage(40);
                                newCharacter.stillAlive();
                                newCharacter.stillHaveMoney();
                                RightMoneyClip();
                            }
                            else
                            {
                                Console.WriteLine("You started mumbling not knowing what to say further angering the owner of the ball who thinks your wasting his time");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You get beaten up by the owner of the ball and his friends taking 50 of your health and each take £15 losing £60");
                                newCharacter.money_lost(60);
                                newCharacter.damage(50);
                                newCharacter.stillHaveMoney();
                                newCharacter.stillAlive();
                                RightMoneyClip();

                            }
                        }
                        else if (finalThrow == "high")
                        {
                            Console.WriteLine("You throw the ball as high as you can....THE OPPONENT DROPS THE BALL YOU WON");
                            Console.WriteLine("Everyone congratualtes you and tells you come back anytime to play again");
                            RightMoneyClip();
                        }
                        else
                        {
                            Console.WriteLine("You panicked under all the preassure and throw the ball 1 meter away from you");
                            Console.WriteLine("Everyone starts laughing at you out of embarrasement you run away losing confidence");
                            RightMoneyClip();
                        }
                    }
                    else if (userCarryOn == "n" || userCarryOn == "no")
                    {
                        Console.WriteLine("You told them thanks for inviting you but your gonna leave!");
                        RightMoneyClip();
                    }
                    else
                    {
                        Console.WriteLine("You started speaking nonsence showing you were concussed pretty bad so they told you it would be better if you left and got help");
                        RightMoneyClip();
                    }
                }
                else
                {
                    Console.WriteLine("You panicked on what to do and the ball hits into your head giving you a concussion forcing you out the rest of the game and losing 20 health points");
                    newCharacter.damage(20);
                    newCharacter.stillAlive(); 
                    RightMoneyClip();
                }    
            }
            else if(userJoinCatchGame == "n" || userJoinCatchGame == "no")
            {
                Console.WriteLine("You thanked the stranger for the offer but your going to pass");
                RightMoneyClip();
            }
            else
            {
                Console.WriteLine("You panicked and said gibberish, the stranger walked away calling you a wierdo");
                RightMoneyClip();
            }
        }

        void LeftStrayAnimal()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You are walking when you see a stray dog running around.");
            Console.WriteLine("After further investigation you realise its a french bull dog and you know you can flip the animal for potentially £400");
            Console.WriteLine("Will you 'y' (yes) approach the dog to tame it or 'n' (no) leave it alone: ");
            string userApproachDog = Console.ReadLine().ToLower();

            if (userApproachDog == "y" || userApproachDog == "yes")
            {
                Console.WriteLine("You have two options on how you will can approach the dog");
                Console.WriteLine("You can 'rush' the dog and try to grab it in one swift move or 'buy' a treat and lure the dog in");
                string userTameMethod = Console.ReadLine().ToLower();
                if (userTameMethod == "rush")
                {
                    Console.WriteLine("You decided to run at the dog full speed to grab it");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("BAD CHOICEE!!The dog bites you dragging you down attakcing you for 5 minutes before a stranger helps you get free");
                    Console.WriteLine("The dog ran away into the bushes out of sight you lose 70 health");
                    newCharacter.damage(70);
                    newCharacter.stillAlive();
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        LeftStrangerInteraction();
                        
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        LeftStrangerInteraction();
                    }
                    else
                    {
                        LeftStrangerInteraction();
                    }
                }
                else if (userTameMethod == "treat")
                {
                    Console.WriteLine("You brought a treat from a dog owner for £2");
                    newCharacter.money_lost(2);
                    Console.WriteLine("You managed to lure the dog in with the treat and capture it successfully");
                    Console.WriteLine("When trying to sell the dog the trapper said he will only pay £200 for it");
                    Console.WriteLine("Will you sell to the 'trapper' for £200 or try and sell the dog for full price to a 'shop' but it has risk!!");
                    string userSellChoice = Console.ReadLine().ToLower();
                    if (userSellChoice == "trapper")
                    {
                        Console.WriteLine("You went for the safe option and it paid off you pocketed a cool £200");
                        newCharacter.money_gained(200);
                        Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                        string checkStats = Console.ReadLine().ToLower();
                        if (checkStats == "y" || checkStats == "yes")
                        {
                            newCharacter.CheckStats();
                            LeftStrangerInteraction();
                        }
                        else if (checkStats == "n" || checkStats == "no")
                        {
                            LeftStrangerInteraction();
                        }
                        else
                        {
                            LeftStrangerInteraction();
                        }
                    }
                    else if(userSellChoice == "shop")
                    {
                        Console.WriteLine("You took the risky option of trying to sell the the legitimate shop but he was lying!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The owner told you he knew it was stolen and beat you up taking the dog for free! Warning you if you went to the police he would tell them the dog was stolen!");
                        Console.WriteLine("You lose 40 health!!!");
                        newCharacter.damage(40);
                        newCharacter.stillAlive();
                        Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                        string checkStats = Console.ReadLine().ToLower();
                        if (checkStats == "y" || checkStats == "yes")
                        {
                            newCharacter.CheckStats();
                            LeftStrangerInteraction();
                        }
                        else if (checkStats == "n" || checkStats == "no")
                        {
                            LeftStrangerInteraction();
                        }
                        else
                        {
                            LeftStrangerInteraction();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You panicked and left the dog losing all the potential money you could have gotten from the dog!");
                        Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                        string checkStats = Console.ReadLine().ToLower();
                        if (checkStats == "y" || checkStats == "yes")
                        {
                            newCharacter.CheckStats();
                            LeftStrangerInteraction();
                        }
                        else if (checkStats == "n" || checkStats == "no")
                        {
                            LeftStrangerInteraction();
                        }
                        else
                        {
                            LeftStrangerInteraction();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You decided against getting the dog so you just leave the dog alone");
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        LeftStrangerInteraction();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        LeftStrangerInteraction();
                    }
                    else
                    {
                        LeftStrangerInteraction();
                    }
                }

            }
            else if (userApproachDog == "n" || userApproachDog == "no")
            {
                Console.WriteLine("You decide it was a safer option carrying on your way rather than risking your health trying to tame the dog.");
                Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                string checkStats = Console.ReadLine().ToLower();
                if (checkStats == "y" || checkStats == "yes")
                {
                    newCharacter.CheckStats();
                    LeftStrangerInteraction();
                }
                else if (checkStats == "n" || checkStats == "no")
                {
                    LeftStrangerInteraction();

                }
                else
                {
                    LeftStrangerInteraction();
                }
            }
            else
            {
                Console.WriteLine("You get distracted with other thoughts completely forgetting about the dog and keep walking on.");
                Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                string checkStats = Console.ReadLine().ToLower();
                if (checkStats == "y" || checkStats == "yes")
                {
                    newCharacter.CheckStats();
                    LeftStrangerInteraction();

                }
                else if (checkStats == "n" || checkStats == "no")
                {
                    LeftStrangerInteraction();
                }
                else
                {
                    LeftStrangerInteraction();
                }
            }

        }

        void RightMoneyClip()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("While walking you see a shining sliver clip will you investigate to see what it is? 'y' (yes) or 'n' (no)");
            string userInvestigate = Console.ReadLine().ToLower();
            if (userInvestigate == "y" || userInvestigate == "yes")
            {
                Console.WriteLine("You reached for the clip and pull out a bunch of money!!");
                Console.WriteLine("You count it and its £200!!");
                newCharacter.money_gained(200);
                Console.WriteLine("After you pocket the money a stranger asks if you have seen a money clip will you 'give' him the money or 'refuse' you saw anything.");
                string userGiveClip = Console.ReadLine().ToLower();
                if (userGiveClip == "give")
                {
                    Console.WriteLine("You said yeah you just found £200 and give it to him");
                    newCharacter.money_lost(200);
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        RightGettingRobbed();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        RightGettingRobbed();

                    }
                    else
                    {
                        RightGettingRobbed();
                    }
                }
                else if( userGiveClip == "refuse")
                {
                    Console.WriteLine("You told the stranger that you dont have any money and never found any money");
                    Console.WriteLine("The stranger demanded that you hand over the money, telling you he saw you pick up the money clip or else there will be concequences!");
                    Console.WriteLine("Will you 'hand over' the £200 or 'stand your ground'!!");
                    string userHandMoney = Console.ReadLine().ToLower();
                    if(userHandMoney == "hand over")
                    {
                        Console.WriteLine("You handed over £200");
                        newCharacter.money_lost(200);
                        Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                        string checkStats = Console.ReadLine().ToLower();
                        if (checkStats == "y" || checkStats == "yes")
                        {
                            newCharacter.CheckStats();
                            RightGettingRobbed();
                        }
                        else if (checkStats == "n" || checkStats == "no")
                        {
                            RightGettingRobbed();
                        }
                        else
                        {
                            RightGettingRobbed();
                        }
                    }
                    else if(userHandMoney == "stand your ground")
                    {
                        Console.WriteLine("You demanded he walks away and dont know what hes on about");
                        Console.WriteLine("The stranger backed off letting you walk away!!");
                        Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                        string checkStats = Console.ReadLine().ToLower();
                        if (checkStats == "y" || checkStats == "yes")
                        {
                            newCharacter.CheckStats();
                            RightGettingRobbed();
                        }
                        else if (checkStats == "n" || checkStats == "no")
                        {
                            RightGettingRobbed();
                        }
                        else
                        {
                            RightGettingRobbed();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You panicked tried running away but the stranger caught up and beat you up.YOU LOST 30 HEALTH AND £250!!");
                        newCharacter.money_lost(250);
                        newCharacter.stillHaveMoney();
                        newCharacter.damage(30);
                        newCharacter.stillAlive();
                        Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                        string checkStats = Console.ReadLine().ToLower();
                        if (checkStats == "y" || checkStats == "yes")
                        {
                            newCharacter.CheckStats();
                            RightGettingRobbed();
                        }
                        else if (checkStats == "n" || checkStats == "no")
                        {
                            RightGettingRobbed();
                        }
                        else
                        {
                            RightGettingRobbed();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You panicked and dropped the money and ran as fast as you could");
                    newCharacter.money_lost(200);
                    Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                    string checkStats = Console.ReadLine().ToLower();
                    if (checkStats == "y" || checkStats == "yes")
                    {
                        newCharacter.CheckStats();
                        RightGettingRobbed();
                    }
                    else if (checkStats == "n" || checkStats == "no")
                    {
                        RightGettingRobbed();
                    }
                    else
                    {
                        RightGettingRobbed();
                    }
                }
            }
            else if(userInvestigate == "n" || userInvestigate == "no")
            {
                Console.WriteLine("You decided against investigating and thought it was better you just carry on.");
                Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                string checkStats = Console.ReadLine().ToLower();
                if (checkStats == "y" || checkStats == "yes")
                {
                    newCharacter.CheckStats();
                    RightGettingRobbed();
                }
                else if (checkStats == "n" || checkStats == "no")
                {
                    RightGettingRobbed();
                }
                else
                {
                    RightGettingRobbed();
                }
            }
            else
            {
                Console.WriteLine("You got distracted completely forgetting about the clip");
                Console.WriteLine("Would you like to check your stats: 'y' or 'n'");
                string checkStats = Console.ReadLine().ToLower();
                if (checkStats == "y" || checkStats == "yes")
                {
                    newCharacter.CheckStats();
                    RightGettingRobbed();
                }
                else if (checkStats == "n" || checkStats == "no")
                {
                    RightGettingRobbed();
                }
                else
                {
                    RightGettingRobbed();
                }
            }

        }

        void LeftStrangerInteraction()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("When walking you get an offer from a stranger to roll dice for £40. Will you 'accept' or 'decline': ");
            string userAcceptInput = Console.ReadLine().ToLower();

            if (userAcceptInput == "accept")
            {
                Console.WriteLine("You chose to roll dice the aim of the game is to roll higher than your opponent");
                Console.WriteLine("Enter 'roll' to roll the dice");
                string userRollDecision = Console.ReadLine().ToLower();
                if (userRollDecision == "roll")
                {
                    int yourRoll = rand.Next(1, 7);
                    Console.WriteLine("You rolled " + yourRoll);
                    int opponentRoll = rand.Next(1, 7);
                    Console.WriteLine("Your opponent rolled " + opponentRoll);

                    if(yourRoll > opponentRoll)
                    {
                        Console.WriteLine("CONGRATS, you won £40 and the stranger handed the money to you and left");
                        newCharacter.money_gained(40);
                        GameOver();
                    }
                    else
                    {
                        Console.WriteLine("YOU LOSTT, now you owe the stranger £40");
                        Console.WriteLine("Will you 'give' the opponent money or 'not'");
                        string userGiveMoney = Console.ReadLine().ToLower();
                        if(userGiveMoney == "give")
                        {
                            Console.WriteLine("You accepted defeat and decided to pay £40");
                            newCharacter.money_lost(40);
                            newCharacter.stillHaveMoney();
                            GameOver();
                        }
                        else
                        {
                            Console.WriteLine("You decided on not giving the stranger the money!");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("WRONG DECISION THE STANGER IN ANGER PULLED OUT A KNIFE AND STABBED YOU TO DEATH AND TOOK ALL YOUR MONEY!!");
                            newCharacter.damage(100);
                            newCharacter.stillAlive();
                            
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You didnt know how to roll a dice and ended up throwing it out of area!!");
                    Console.WriteLine("The stranger demanded £10 for a new dice or else");
                    Console.WriteLine("Will you 'give' him the money or 'not': ");
                    string userPayOrNot = Console.ReadLine().ToLower();
                    if (userPayOrNot == "give")
                    {
                        Console.WriteLine("You payed the man the money he asked for and carried on walking");
                        newCharacter.money_lost(10);
                        newCharacter.stillHaveMoney();
                        GameOver();
                    }
                    else if(userPayOrNot == "not")
                    {
                        Console.WriteLine("You stood your ground and told the stranger no your not giving him any money");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bad decision the stranger pulled out a knife and stabbed you!! YOU LOST 70 HEALTH and £20 POUNDS");
                        newCharacter.money_lost(20);
                        newCharacter.damage(70);
                        newCharacter.stillAlive();
                        newCharacter.stillHaveMoney();
                        GameOver();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You started mumbling and the stranger got mad pulling out a knife and stabbed you!! YOU LOST 70 HEALTH and £20 POUNDS");
                        newCharacter.money_lost(20);
                        newCharacter.damage(70);
                        newCharacter.stillAlive();
                        newCharacter.stillHaveMoney();
                        GameOver();
                    }
                }

            }
            else if(userAcceptInput == "decline")
            {
                Console.WriteLine("You thanked the stanger for the oppertunity but will have to decline");
                GameOver();
            }
            else
            {
                Console.WriteLine("You couldnt make up your mind making your opponent angry who walks off");
                GameOver();
            }
        }

        void RightGettingRobbed()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You are walking when you get approached by a stanger is poking you with what feels like a gun!!");
            Console.WriteLine("The stranger tells you that hand him £50 now or your dead!!");
            Console.WriteLine("Will you 'give' the stranger money to save your life or 'dont' give him money to see if hes bluffing");
            string userMoneyDecision = Console.ReadLine().ToLower();
            if (userMoneyDecision == "give")
            {
                Console.WriteLine("You wernt willing to risk your life over £50 so you told him you would give it to him!");
                newCharacter.money_lost(50);
                newCharacter.stillHaveMoney();
                GameOver();
            }
            else if(userMoneyDecision == "dont")
            {
                Console.WriteLine("You told him that you knew he was bluffing and back off!!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("To show you he wasnt bluffing he shoots you in the leg you lose 50 health!!");
                newCharacter.damage(50);
                newCharacter.stillAlive();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("The stanger says now you believe him give him £100 or you die!!");
                Console.WriteLine("Will you 'give' him the money or 'attack' him and try to out muscle him!");
                string userGiveMoney = Console.ReadLine().ToLower();
                if(userGiveMoney == "give")
                {
                    newCharacter.money_lost(100);
                    newCharacter.stillHaveMoney();
                    Console.WriteLine("You gave the stranger money in exchange for your life!");
                    GameOver();
                }
                else
                {
                    Console.WriteLine("You suddenly attack the stranger tring to out power him....");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The stanger gets to his gun and shoots you multiple times!!");
                    Console.WriteLine("YOU DIED!!!!");
                    newCharacter.damage(100);
                    newCharacter.stillAlive();

                }
            }
            else
            {
                Console.WriteLine("The stranger starts getting nervous and your mumbling nonsense, causing him to pull the trigger. ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU DIEDDD!!!!");
                newCharacter.damage(100);
                newCharacter.stillAlive();
            }
        }

        void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CONGRATULATIONS YOU MADE IT TO THE END OF THE GAME!!");
            Console.WriteLine("Thank you for playing!!");
            Console.WriteLine(newCharacter._name + " you finished on £" + newCharacter.bankBalance + " with " + newCharacter.health + " health");
        }
    }
}



