using RubiksTree;
using static System.Runtime.InteropServices.JavaScript.JSType;

var allCubeStates = new List<CubeState>();
var solvedState = new CubeState(
	new FaceColour[,,]
	{
		{
			{ FaceColour.White, FaceColour.White },
			{ FaceColour.White, FaceColour.White }
		},
		{
			{ FaceColour.Red, FaceColour.Red },
			{ FaceColour.Red, FaceColour.Red }
		},
		{
			{ FaceColour.Yellow, FaceColour.Yellow },
			{ FaceColour.Yellow, FaceColour.Yellow }
		},
		{
			{ FaceColour.Orange, FaceColour.Orange },
			{ FaceColour.Orange, FaceColour.Orange }
		},
		{
			{ FaceColour.Blue, FaceColour.Blue },
			{ FaceColour.Blue, FaceColour.Blue }
		},
		{
			{ FaceColour.Green, FaceColour.Green },
			{ FaceColour.Green, FaceColour.Green }
		}
	},
	0,
	null);
allCubeStates.Add(solvedState);
var queue = new Queue<Task>();
var task = solvedState.GetGenAllTurnsTask(allCubeStates, queue);
lock (queue)
{
	queue.Enqueue(task);
}
var queueItemsProcessed = 0;
Console.WriteLine("Finding cube states...");
while (queue.Count > 0)
{
	if (queueItemsProcessed % 1000 == 0)
	{
		int count;
		lock (queue)
		{
			count = queue.Count;
		}
		Console.WriteLine($"{queueItemsProcessed}: {count}");
	}
	bool gotItem;
	lock (queue)
	{
		gotItem = queue.TryDequeue(out task);
	}
	if (gotItem && task is not null)
	{
		task.RunSynchronously();
		queueItemsProcessed++;
	}
}
Console.WriteLine("Done.");
