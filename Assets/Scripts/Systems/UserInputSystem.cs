using Aspects;
using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
	public partial class UserInputSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				var playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
				var movingAspect = SystemAPI.GetAspectRW<MovingAspect>(playerEntity);
				movingAspect.StartAcceleration();
				SystemAPI.SetComponentEnabled<MovingComponent>(playerEntity, true);
			}
			
			if (Input.GetKeyUp(KeyCode.W))
			{
				var playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
				var movingAspect = SystemAPI.GetAspectRW<MovingAspect>(playerEntity);
				movingAspect.EndAcceleration();
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
				var playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
				var rotationAspect = SystemAPI.GetAspectRW<RotationAspect>(playerEntity);
				rotationAspect.RightRotation();
				SystemAPI.SetComponentEnabled<RotatingComponent>(playerEntity, true);
			}

			if (Input.GetKeyUp(KeyCode.D))
			{
				var playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
				var rotationAspect = SystemAPI.GetAspectRW<RotationAspect>(playerEntity);
				rotationAspect.StopRotation();
				SystemAPI.SetComponentEnabled<RotatingComponent>(playerEntity, false);
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				var playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
				var rotationAspect = SystemAPI.GetAspectRW<RotationAspect>(playerEntity);
				rotationAspect.LeftRotation();
				SystemAPI.SetComponentEnabled<RotatingComponent>(playerEntity, true);
			}

			if (Input.GetKeyUp(KeyCode.A))
			{
				var playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
				var rotationAspect = SystemAPI.GetAspectRW<RotationAspect>(playerEntity);
				rotationAspect.StopRotation();
				SystemAPI.SetComponentEnabled<RotatingComponent>(playerEntity, false);
			}
		}
	}
}