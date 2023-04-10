using Components;
using Unity.Entities;

namespace Aspects
{
	public readonly partial struct PlayerAspect : IAspect
	{
		public readonly Entity entity;

		private readonly RefRO<PlayerTag> _tag;
		
		
	}
}