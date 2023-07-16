using RubiksTree;

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
var queue = new Queue<Action>();
lock (queue)
{
	queue.Enqueue(solvedState.GetGenAllTurnsAction(allCubeStates, queue));
}
var queueItemsProcessed = 0;
while (queueItemsProcessed < 1)
{
	if (queueItemsProcessed % 1000 == 0)
	{
		Console.WriteLine($"{queueItemsProcessed}: {queue.Count}");
	}
	//await Task.Run(queue.Dequeue());
	//queueItemsProcessed++;
	lock (queue)
	{
		if (queue.TryDequeue(out var action))
		{
			_ = Task.Run(action);
			queueItemsProcessed++;
		}
	}
}
Console.WriteLine("Done.");
var groupedStates = allCubeStates.GroupBy(x => x.Depth);
Console.ReadKey();
