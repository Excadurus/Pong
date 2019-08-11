using _2DVector;

namespace PhysicsEngine
{
	public interface IPhysicObject
	{
		double Mass { get; set; }
		//Vector Gravity { get; set; }
		//Vector Force { get; set; }
		Vector Velocity { get; set; }
		//DateTime PreviousTime { get; set; }//get this out!

		void AddForce(Vector force); // MUST CHANGE VELOCITY
	}
}
