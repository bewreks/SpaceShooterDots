using Components;
using Unity.Entities;
using UnityEngine;

namespace Authorings
{
	public class Game : MonoBehaviour
	{
		public float      frictionForce;
		public float      playerMaxSpeed;
		public float      maxRotationSpeed;
		public float      playerAcceleration;
		public GameObject playerPrefab;
	}

	public class GameBaker : Baker<Game>
	{
		public override void Bake(Game authoring)
		{
			var gameEntity = GetEntity(TransformUsageFlags.None);
			AddComponent(gameEntity, new GameProperties
			                         {
				                         frictionForce = authoring.frictionForce,
				                         playerAcceleration = authoring.playerAcceleration,
				                         playerMaxSpeed = authoring.playerMaxSpeed,
				                         maxRotationSpeed = authoring.maxRotationSpeed,
				                         playerPrefab = GetEntity(authoring.playerPrefab, TransformUsageFlags.Dynamic)
			                         });
		}
	}
}