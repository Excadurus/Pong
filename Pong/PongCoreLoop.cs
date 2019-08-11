using System;
using TransformEngine;
using ConsoleRenderer;
using System.Threading;
using _2DVector;
using PhysicsEngine;
using Logic;

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

	}
}
