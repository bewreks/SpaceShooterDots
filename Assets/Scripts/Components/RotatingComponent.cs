using Unity.Entities;

namespace Components
{
	public struct RotatingComponent : IComponentData,
	                                  IEnableableComponent
	{
		public float maxRotationSpeed;
		public float curRotationSpeed;
		public float curRotation;
	}
}