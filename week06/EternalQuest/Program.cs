using System;

// ----------------------------------------------------------------------------------
// REPORT ON EXCEEDING REQUIREMENTS
// ----------------------------------------------------------------------------------
// To exceed the requirements, I have implemented a Leveling and Title System.
// 
// 1. Level Calculation: In the GoalManager.DisplayPlayerInfo() method, 
//    the program calculates the user's level based on their current score 
//    (Score / 1000).
//
// 2. Dynamic Titles: Based on the calculated level, the user is assigned a 
//    unique rank/title (e.g., "Novice Goal Setter", "Master of Habit", "Eternal Legend").
//    This adds an extra layer of gamification to encourage the user to earn more points.
//
// 3. Visual Feedback: The score display uses colors to highlight the current 
//    points and level.
// ----------------------------------------------------------------------------------

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}