using System;
// for ListOf
using System.Collections.Generic;

public class Program {

  // Actor in the game
  class Actor  {
    protected string actorName;      // can be accessed by the subclasses
    private int x;    // x coordinate
    private int y;    // y coordinate

    // Constructor
    public Actor (string name) {
      this.actorName = name;

      // initialise coordinates to 0
      x = 0;
      y = 0;        
    }

    public string GetName() {
      return actorName;
    }

    public int GetX() {
      return x;
    }

    public void SetX(int x) {
      this.x = x;
    }

    public int GetY(){
      return y;
    }

    public void SetY(int y) {
      this.y = y;
    }

    // getter to get the coordinates of the object 
    public (int, int) GetCoordinates(){
      return (x, y);
    }
    // draw( )method.
    // Derived classes may provide an implementation
    public virtual void Draw() {
      Console.WriteLine ("Actor {0}: Base draw() method for an actor", actorName);
    }

    public virtual void Move(int x, int y) {
      Console.WriteLine("Me no movey");
    }
  }

  // Archer class.
  // Attributes: bowLength
  // Method: implement the draw() method to override
  // the implementation the base class
  class Archer : Actor {
    private int bowLength;

    // Constructor for Archer.
    // Call the constructor for Actor using the name
    public Archer (string name, int bowLength) : base (name) {
      this.bowLength = bowLength;
    }
    public override void Draw() {
      Console.WriteLine ("Archer: {0} with bowlength {1}", this.actorName, bowLength);
    }

    public override void Move(int x, int y)
    {
      int originalX = this.GetX();

      this.SetX(originalX + x);
    }
  }
  
  class Swordsman : Actor {
    // Sword length in mm
    private int swordLength;
    public Swordsman(string name, int swordLength): base(name) {
      this.swordLength = swordLength;
    }
    public override void Draw() {
      Console.WriteLine ("Swordsman: {0} with sword length of {1}", this.actorName, swordLength);
    }

    public override void Move(int x, int y)
    {
      int originalY = this.GetY();

      this.SetY(originalY + y);
    }
  }
  
  class Knight : Actor {
    // Sword length in mm
    private int swordLength;
    public Knight(string name, int swordLength): base(name) {
      this.swordLength = swordLength;
    }
    public override void Draw() {
      Console.WriteLine ("Knight: {0} with sword length of {1}", this.actorName, swordLength);
    }

    public override void Move(int x, int y)
    {
      int originalX = this.GetX();
      int originalY = this.GetY();

      this.SetX(originalX + x);
      this.SetY(originalY + y);
    }
  }
  
  public static void Main (string[] args) {

    // Create a list of Actor object
    List<Actor> actorList = new List<Actor>();

    // Add instances of Actor objects to the actorList
    actorList.Add (new Actor ("Ian McEwan"));
    actorList.Add (new Archer ("Legolas", 120));
    actorList.Add (new Knight ("Donald duck",250));
    actorList.Add (new Swordsman("Goofy",150));
    
    // Iterate through the list of actors and call the 
    // call the draw method for each one
    foreach (Actor actor in actorList) {
      // draw the actor
      actor.Draw();        
      
      // Print the coordinates of the actor
      int actorX = actor.GetX();
      int actorY = actor.GetY();

      Console.WriteLine("{0} at ({1}, {2})", actor.GetName(), actorX, actorY);

      // Move actor
      actor.Move(5, 6);

      // Print the coordinates of the actor
      actorX = actor.GetX();
      actorY = actor.GetY();

      Console.WriteLine("{0} at ({1}, {2})", actor.GetName(), actorX, actorY);

      Console.WriteLine();
    }
  }
}