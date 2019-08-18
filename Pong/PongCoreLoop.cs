using System;
using TransformEngine;
using ConsoleRenderer;
using System.Threading;
using _2DVector;
using PhysicsEngine;
using Logic;
using Input;

namespace Worker
{
	public class PongCoreLoop : CoreLoop
	{
		//Player Scores
		int PlayerOneScore;
		int PlayerTwoScore;
		int MaxScore = 5;

		//Playground stuff, make this a separate class later? 
		double playgroundWidth;
		double playgroundHeight;

		//Input Threads
		Thread leftPlayer;
		Thread rightPlayer;

		//Objects needing Initializing
		Pong pong;
		Wall leftWall;
		Wall rightWall;
		Border topBorder;
		Border bottomBorder;


		public PongCoreLoop(double playgroundWidth,double playgroundHeight,double fps)
		{
			PlayerOneScore = 0;
			PlayerTwoScore = 0;

			this.playgroundWidth = playgroundWidth;
			this.playgroundHeight = playgroundHeight;

			this.fps = fps;

			pong = new Pong(playgroundWidth/2, playgroundHeight / 2, 10, 10);
			leftWall = new Wall(1, 1, 0, 2);
			rightWall = new Wall(playgroundWidth - 3, 1, 0, 2);
			topBorder = new Border(5, 1, 0, 0);
			bottomBorder = new Border(5, playgroundHeight - 2, 0, 0);

			renderer.movingTransformables.Add(pong);
			renderer.movingTransformables.Add(leftWall);
			renderer.movingTransformables.Add(rightWall);
			renderer.staticTransformables.Add(topBorder);
			renderer.staticTransformables.Add(bottomBorder);

			physicsEngine.Add(pong);
			physicsEngine.Add(leftWall);
			physicsEngine.Add(rightWall);
			physicsEngine.Add(topBorder);
			physicsEngine.Add(bottomBorder);

			//Add New Threads here :)
			IInputGetter leftInputGetter = new LeftPlayerConsoleInputGetter(new WallMoverUp(leftWall), new WallMoverDown(leftWall));
			leftPlayer = new Thread(leftInputGetter.Act);
			leftPlayer.IsBackground = true;
			leftPlayer.Start();
			//Put All inputs in One place, don't separate them;
			IInputGetter rightInputGetter = new RightPlayerConsoleInputGetter(new WallMoverUp(rightWall), new WallMoverDown(rightWall));
			rightPlayer = new Thread(rightInputGetter.Act);
			rightPlayer.IsBackground = true;
			rightPlayer.Start();
		}

		protected override void OnBeforePhysic()
		{
			CheckScoreAndResetBallPosition();
			pong.CheckPongCollision(leftWall,rightWall,topBorder,bottomBorder);
		}

		protected override void OnAfterPhysic()
		{
			CheckPlayerScoresToDetermineFinish();

		}


		private void CheckScoreAndResetBallPosition()
		{
			if (BallHasPassedLeftBoundary())
			{
				PlayerOneScore++;
				pong.ResetPosition(playgroundWidth / 2, playgroundHeight / 2);
				pong.ResetVelocity(Math.Abs(pong.Velocity.X), Math.Abs(pong.Velocity.Y));
				return;
			}
			else if (BallHasPassedRightBoundary())
			{
				PlayerTwoScore++;
				pong.ResetPosition(playgroundWidth / 2, playgroundHeight / 2);
				pong.ResetVelocity(-1 * Math.Abs(pong.Velocity.X), -1 * Math.Abs(pong.Velocity.Y));
				return;
			}
		}

		private bool BallHasPassedLeftBoundary()
		{
			return pong.Position.X <= 0;
		}

		private bool BallHasPassedRightBoundary()
		{
			return pong.Position.X >= playgroundWidth;
		}

		private void CheckPlayerScoresToDetermineFinish()
		{
			if (PlayerOneScore >= MaxScore)
			{
				Exit();
			}
			else if (PlayerTwoScore >= MaxScore)
			{
				Exit();
			}
		}

		private class WallMoverUp : IInputTask
		{
			Wall wall;
			public WallMoverUp(Wall wall)
			{
				this.wall = wall;
			}
			public void Act()
			{
				wall.Velocity = new Vector(0, -10);
			}
		}
		private class WallMoverDown : IInputTask
		{
			Wall wall;
			public WallMoverDown(Wall wall)
			{
				this.wall = wall;
			}
			public void Act()
			{
				wall.Velocity = new Vector(0, 10);
			}
		}
	}
}
