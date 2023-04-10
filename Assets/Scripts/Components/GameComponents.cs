using Unity.Entities;

namespace Components
{
	public struct GameProperties : IComponentData
	{
		public float  playerMaxSpeed;
		public float  playerAcceleration;
		public float  maxRotationSpeed;
		public float  frictionForce;
		public Entity playerPrefab;
	}
}