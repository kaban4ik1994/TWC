using System.Data.Entity;

namespace TWC.Entities
{
	public class TwcContextInitializer : CreateDatabaseIfNotExists<TwcContext>
	{
		protected override void Seed(TwcContext context)
		{
			base.Seed(context);
		}
	}
}
