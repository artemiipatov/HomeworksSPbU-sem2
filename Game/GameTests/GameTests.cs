using System;
using System.IO;
using NUnit.Framework;

namespace GameTests;

public class Tests
{
    [Test]
    public void ExceptionShouldBeThrownIfThereAreMoreThanOneCharactersOnTheMap()
    {
        string[] mapArray = { "|-------|", "|@      |", "|       |", "|     @ |", "|-------|" };
        using (var writer = new StreamWriter(File.Open("../../../TestMap.txt", FileMode.Create)))
        {
            foreach (var line in mapArray)
            {
                writer.WriteLine(line);
            }
        }
        var game = new Game.Game();
        Assert.Throws<Exception>(() => game.GenerateMap("../../../TestMap.txt"));
    }

    [Test]
    public void OnLeftTesting()
    {
        string[] mapArray = { "|---|", "|   |", "| + |", "|  @|", "|---|" };
        using (var writer = new StreamWriter(File.Open("../../../TestMap.txt", FileMode.Create)))
        {
            foreach (var line in mapArray)
            {
                writer.WriteLine(line);
            }
        }

        var game = new Game.Game();
        game.GenerateMap("../../../TestMap.txt");
        (int, int) startingPosition = game.Position;

        game.OnLeft(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1 - 1, startingPosition.Item2), game.Position);
        game.OnLeft(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1 - 2, startingPosition.Item2), game.Position);
        game.OnLeft(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1 - 2, startingPosition.Item2), game.Position);
    }
    
    [Test]
    public void OnRightTesting()
    {
        string[] mapArray = { "|---|", "|@  |", "| + |", "|   |", "|---|" };
        using (var writer = new StreamWriter(File.Open("../../../TestMap.txt", FileMode.Create)))
        {
            foreach (var line in mapArray)
            {
                writer.WriteLine(line);
            }
        }

        var game = new Game.Game();
        game.GenerateMap("../../../TestMap.txt");
        
        (int, int) startingPosition = game.Position;
        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1 + 1, startingPosition.Item2), game.Position);
        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1 + 2, startingPosition.Item2), game.Position);
        game.OnRight(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1 + 2, startingPosition.Item2), game.Position);
    }
    
    [Test]
    public void OnUpTesting()
    {
        string[] mapArray = { "|---|", "|   |", "| + |", "|@  |", "|---|" };
        using (var writer = new StreamWriter(File.Open("../../../TestMap.txt", FileMode.Create)))
        {
            foreach (var line in mapArray)
            {
                writer.WriteLine(line);
            }
        }

        var game = new Game.Game();
        game.GenerateMap("../../../TestMap.txt");
        
        (int, int) startingPosition = game.Position;
        game.OnUp(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1, startingPosition.Item2 - 1), game.Position);
        game.OnUp(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1, startingPosition.Item2 - 2), game.Position);
        game.OnUp(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1, startingPosition.Item2 - 2), game.Position);
    }
    
    [Test]
    public void OnDownTesting()
    {
        string[] mapArray = { "|---|", "|@  |", "| + |", "|   |", "|---|" };
        using (var writer = new StreamWriter(File.Open("../../../TestMap.txt", FileMode.Create)))
        {
            foreach (var line in mapArray)
            {
                writer.WriteLine(line);
            }
        }

        var game = new Game.Game();
        game.GenerateMap("../../../TestMap.txt");
        
        (int, int) startingPosition = game.Position;
        game.OnDown(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1, startingPosition.Item2 + 1), game.Position);
        game.OnDown(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1, startingPosition.Item2 + 2), game.Position);
        game.OnDown(this, EventArgs.Empty);
        Assert.AreEqual((startingPosition.Item1, startingPosition.Item2 + 2), game.Position);
    }

    [Test]
    public void WallsShouldBeDetectedCorrectly()
    {
        
    }
}