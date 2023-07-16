namespace RubiksTree;
internal class CubeState
{
	// front, right, back, left, top, bottom
	private readonly FaceColour[,,] Faces;
	private CubeState? TurnBottomLeftCubeState;
	private CubeState? TurnBottomRightCubeState;
	private CubeState? TurnRightForwardCubeState;
	private CubeState? TurnRightBackCubeState;
	private CubeState? TurnBackLeftCubeState;
	private CubeState? TurnBackRightCubeState;
#pragma warning disable IDE0052 // Remove unread private members
	private readonly CubeState? SolutionMove;
#pragma warning restore IDE0052 // Remove unread private members
	public readonly int Depth;

	public CubeState(FaceColour[,,] faces, int depth, CubeState? solutionMove)
	{
		Faces = faces;
		Depth = depth;
		SolutionMove = solutionMove;
	}

	private FaceColour[,,] DeepCopyFaces()
	{
		var result = new FaceColour[Faces.GetLength(0), Faces.GetLength(1), Faces.GetLength(2)];
		Array.Copy(Faces, result, Faces.Length);
		return result;
	}

	public Task GetGenAllTurnsTask(IList<CubeState> allCubeStates, Queue<Task> queue) =>
		new(() => GenAllTurns(allCubeStates, queue));

	public void GenAllTurns(IList<CubeState> allCubeStates, Queue<Task> queue)
	{
		var turnBottomLeftFaces = DeepCopyFaces();
		turnBottomLeftFaces[0, 1, 0] = Faces[1, 1, 0];
		turnBottomLeftFaces[0, 1, 1] = Faces[1, 1, 1];
		turnBottomLeftFaces[1, 1, 0] = Faces[2, 1, 0];
		turnBottomLeftFaces[1, 1, 1] = Faces[2, 1, 1];
		turnBottomLeftFaces[2, 1, 0] = Faces[3, 1, 0];
		turnBottomLeftFaces[2, 1, 1] = Faces[3, 1, 1];
		turnBottomLeftFaces[3, 1, 0] = Faces[0, 1, 0];
		turnBottomLeftFaces[3, 1, 1] = Faces[0, 1, 1];
		turnBottomLeftFaces[5, 0, 0] = Faces[5, 0, 1];
		turnBottomLeftFaces[5, 0, 1] = Faces[5, 1, 1];
		turnBottomLeftFaces[5, 1, 0] = Faces[5, 0, 0];
		turnBottomLeftFaces[5, 1, 1] = Faces[5, 1, 0];
		TurnBottomLeftCubeState = ProcessFaces(turnBottomLeftFaces, TurnBottomLeftCubeState, allCubeStates, queue);
		TurnBottomLeftCubeState.TurnBottomRightCubeState = this;

		var turnBottomRightFaces = DeepCopyFaces();
		turnBottomRightFaces[0, 1, 0] = Faces[3, 1, 0];
		turnBottomRightFaces[0, 1, 1] = Faces[3, 1, 1];
		turnBottomRightFaces[1, 1, 0] = Faces[0, 1, 0];
		turnBottomRightFaces[1, 1, 1] = Faces[0, 1, 1];
		turnBottomRightFaces[2, 1, 0] = Faces[1, 1, 0];
		turnBottomRightFaces[2, 1, 1] = Faces[1, 1, 1];
		turnBottomRightFaces[3, 1, 0] = Faces[2, 1, 0];
		turnBottomRightFaces[3, 1, 1] = Faces[2, 1, 1];
		turnBottomRightFaces[5, 0, 0] = Faces[5, 1, 0];
		turnBottomRightFaces[5, 0, 1] = Faces[5, 0, 0];
		turnBottomRightFaces[5, 1, 0] = Faces[5, 1, 1];
		turnBottomRightFaces[5, 1, 1] = Faces[5, 0, 1];
		TurnBottomRightCubeState = ProcessFaces(turnBottomRightFaces, TurnBottomRightCubeState, allCubeStates, queue);
		TurnBottomRightCubeState.TurnBottomLeftCubeState = this;

		var turnRightForwardFaces = DeepCopyFaces();
		turnRightForwardFaces[0, 0, 1] = Faces[4, 0, 1];
		turnRightForwardFaces[0, 1, 1] = Faces[4, 1, 1];
		turnRightForwardFaces[4, 0, 1] = Faces[2, 0, 1];
		turnRightForwardFaces[4, 1, 1] = Faces[2, 1, 1];
		turnRightForwardFaces[2, 0, 1] = Faces[5, 0, 1];
		turnRightForwardFaces[2, 1, 1] = Faces[5, 1, 1];
		turnRightForwardFaces[5, 0, 1] = Faces[0, 0, 1];
		turnRightForwardFaces[5, 1, 1] = Faces[0, 1, 1];
		turnRightForwardFaces[1, 0, 0] = Faces[1, 0, 1];
		turnRightForwardFaces[1, 0, 1] = Faces[1, 1, 1];
		turnRightForwardFaces[1, 1, 0] = Faces[1, 0, 0];
		turnRightForwardFaces[1, 1, 1] = Faces[1, 1, 0];
		TurnRightForwardCubeState = ProcessFaces(turnRightForwardFaces, TurnRightForwardCubeState, allCubeStates, queue);
		TurnRightForwardCubeState.TurnRightBackCubeState = this;

		var turnRightBackFaces = DeepCopyFaces();
		turnRightBackFaces[0, 0, 1] = Faces[5, 0, 1];
		turnRightBackFaces[0, 1, 1] = Faces[5, 1, 1];
		turnRightBackFaces[4, 0, 1] = Faces[0, 0, 1];
		turnRightBackFaces[4, 1, 1] = Faces[0, 1, 1];
		turnRightBackFaces[2, 0, 1] = Faces[4, 0, 1];
		turnRightBackFaces[2, 1, 1] = Faces[4, 1, 1];
		turnRightBackFaces[5, 0, 1] = Faces[2, 0, 1];
		turnRightBackFaces[5, 1, 1] = Faces[2, 1, 1];
		turnRightBackFaces[1, 0, 0] = Faces[1, 1, 0];
		turnRightBackFaces[1, 0, 1] = Faces[1, 0, 0];
		turnRightBackFaces[1, 1, 0] = Faces[1, 1, 1];
		turnRightBackFaces[1, 1, 1] = Faces[1, 0, 1];
		TurnRightBackCubeState = ProcessFaces(turnRightBackFaces, TurnRightBackCubeState, allCubeStates, queue);
		TurnRightBackCubeState.TurnRightForwardCubeState = this;

		var turnBackLeftFaces = DeepCopyFaces();
		turnBackLeftFaces[1, 0, 1] = Faces[5, 1, 0];
		turnBackLeftFaces[1, 1, 1] = Faces[5, 1, 1];
		turnBackLeftFaces[4, 0, 0] = Faces[1, 0, 1];
		turnBackLeftFaces[4, 0, 1] = Faces[1, 1, 1];
		turnBackLeftFaces[3, 0, 0] = Faces[4, 0, 0];
		turnBackLeftFaces[3, 1, 0] = Faces[4, 0, 1];
		turnBackLeftFaces[5, 1, 0] = Faces[3, 0, 0];
		turnBackLeftFaces[5, 1, 1] = Faces[3, 1, 0];
		turnBackLeftFaces[2, 0, 0] = Faces[2, 1, 0];
		turnBackLeftFaces[2, 0, 1] = Faces[2, 0, 0];
		turnBackLeftFaces[2, 1, 0] = Faces[2, 1, 1];
		turnBackLeftFaces[2, 1, 1] = Faces[2, 0, 1];
		TurnBackLeftCubeState = ProcessFaces(turnBackLeftFaces, TurnBackLeftCubeState, allCubeStates, queue);
		TurnBackLeftCubeState.TurnBackRightCubeState = this;

		var turnBackRightFaces = DeepCopyFaces();
		turnBackRightFaces[1, 0, 1] = Faces[4, 0, 0];
		turnBackRightFaces[1, 1, 1] = Faces[4, 0, 1];
		turnBackRightFaces[4, 0, 0] = Faces[3, 0, 0];
		turnBackRightFaces[4, 0, 1] = Faces[3, 1, 0];
		turnBackRightFaces[3, 0, 0] = Faces[5, 1, 0];
		turnBackRightFaces[3, 1, 0] = Faces[5, 1, 1];
		turnBackRightFaces[5, 1, 0] = Faces[1, 0, 1];
		turnBackRightFaces[5, 1, 1] = Faces[1, 1, 1];
		turnBackRightFaces[2, 0, 0] = Faces[2, 0, 1];
		turnBackRightFaces[2, 0, 1] = Faces[2, 1, 1];
		turnBackRightFaces[2, 1, 0] = Faces[2, 0, 0];
		turnBackRightFaces[2, 1, 1] = Faces[2, 1, 0];
		TurnBackRightCubeState = ProcessFaces(turnBackRightFaces, TurnBackRightCubeState, allCubeStates, queue);
		TurnBackRightCubeState.TurnBackLeftCubeState = this;
	}

	private CubeState ProcessFaces(
		FaceColour[,,] faces,
		CubeState? cubeState,
		IList<CubeState> allCubeStates,
		Queue<Task> queue)
	{
		cubeState = GetCubeStateIfExists(faces, allCubeStates, cubeState);
		if (cubeState is null)
		{
			cubeState = CreateNewCubeState(faces, allCubeStates);
			var task = cubeState.GetGenAllTurnsTask(allCubeStates, queue);
			lock (queue)
			{
				queue.Enqueue(task);
			}
		}
		return cubeState;
	}

	private static CubeState? GetCubeStateIfExists(FaceColour[,,] inputFaces, IList<CubeState> allCubeStates, CubeState? cubeState)
	{
		if (cubeState is not null)
		{
			return cubeState;
		}
		for (var i = 0; i < allCubeStates.Count; i++)
		{
			var testCubeState = allCubeStates[i];
			if (AreFacesEqual(inputFaces, testCubeState?.Faces))
			{
				return testCubeState;
			}
		}
		return null;
	}

	private static bool AreFacesEqual(FaceColour[,,] inputFaces, FaceColour[,,]? testFaces)
	{
		if (testFaces is null)
		{
			return false;
		}
		var inputFacesEnumerator = inputFaces.GetEnumerator();
		var testFacesEnumerator = testFaces.GetEnumerator();
		while (inputFacesEnumerator.MoveNext())
		{
			_ = testFacesEnumerator.MoveNext();
			if ((FaceColour)inputFacesEnumerator.Current != (FaceColour)testFacesEnumerator.Current)
			{
				return false;
			}
		}
		return true;
	}

	private CubeState CreateNewCubeState(FaceColour[,,] faces, IList<CubeState> allCubeStates)
	{
		var cubeState = new CubeState(faces, Depth + 1, this);
		allCubeStates.Add(cubeState);
		return cubeState;
	}
}
