namespace TicTacToe;

using System;
using System.Collections.Generic;

class Game
{
    private const int AmountOfButtons = 9;

    private static int[] Map = new int[AmountOfButtons];

    private static int numberOfCurrentMove = 0;

    private static HashSet<int> alreadyPressedButtons = new HashSet<int>();

    private enum States
    {
        InProgress,
        WinX,
        WinO,
        Tie
    };

    private static States WhatState(int[] map)
    {
        //tie
        var counter = 0;
        foreach (var stateOfButton in map)
        {
            if (stateOfButton != 0)
            {
                ++counter;
            }
        }
        if (counter == AmountOfButtons)
        {
            return States.Tie;
        }

        //wins
        for (int stateOfButton = 1; stateOfButton <= 2; ++stateOfButton)
        {
            // columns
            if ((map[0] == stateOfButton && map[1] == stateOfButton && map[2] == stateOfButton)
                || (map[3] == stateOfButton && map[4] == stateOfButton && map[5] == stateOfButton)
                || (map[6] == stateOfButton && map[7] == stateOfButton && map[8] == stateOfButton)
                // rows
                || (map[0] == stateOfButton && map[3] == stateOfButton && map[6] == stateOfButton)
                || (map[1] == stateOfButton && map[4] == stateOfButton && map[7] == stateOfButton)
                || (map[2] == stateOfButton && map[5] == stateOfButton && map[8] == stateOfButton)
                // diagonals
                || (map[0] == stateOfButton && map[4] == stateOfButton && map[8] == stateOfButton)
                || (map[2] == stateOfButton && map[4] == stateOfButton && map[6] == stateOfButton))
            {
                if (stateOfButton == 1)
                {
                    return States.WinX;
                }
                return States.WinO;
            }
        }

        return States.InProgress;
    }

    public static int MakeMove(int numberOfButton)
    {
        if (alreadyPressedButtons.Contains(numberOfButton))
        {
            throw new ArgumentException();
        }

        alreadyPressedButtons.Add(numberOfButton);

        var printingValue = 0;
        if (numberOfCurrentMove++ % 2 == 0)
        {
            printingValue = 1;
        }
        else
        {
            printingValue = 2;
        }

        Map[numberOfButton - 1] = printingValue;

        switch (WhatState(Map))
        {
            case States.Tie:
                if (printingValue == 1)
                {
                    return 3;
                }
                return 4;
            case States.InProgress:
                return printingValue;
            case States.WinX:
                return 5;
            case States.WinO:
                return 6;
        }
        return 0;
    }
}