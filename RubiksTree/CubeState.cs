namespace RubiksTree;
internal class CubeState
{
	// front, right, back, left, top, bottom
	public readonly FaceColour[,,] Faces;
	public CubeState? TurnBottomClockwiseCubeState;
	public CubeState? TurnBottomAnticlockwiseCubeState;
	public CubeState? TurnRightClockwiseCubeState;
	public CubeState? TurnRightAnticlockwiseCubeState;
	public CubeState? TurnBackClockwiseCubeState;
	public CubeState? TurnBackAnticlockwiseCubeState;
#pragma warning disable IDE0052 // Remove unread private members
	public readonly CubeState? SolutionMove;
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
		var turnBottomClockwiseFaces = DeepCopyFaces();
		turnBottomClockwiseFaces[0, 1, 0] = Faces[3, 1, 0];
		turnBottomClockwiseFaces[0, 1, 1] = Faces[3, 1, 1];
		turnBottomClockwiseFaces[1, 1, 0] = Faces[0, 1, 0];
		turnBottomClockwiseFaces[1, 1, 1] = Faces[0, 1, 1];
		turnBottomClockwiseFaces[2, 1, 0] = Faces[1, 1, 0];
		turnBottomClockwiseFaces[2, 1, 1] = Faces[1, 1, 1];
		turnBottomClockwiseFaces[3, 1, 0] = Faces[2, 1, 0];
		turnBottomClockwiseFaces[3, 1, 1] = Faces[2, 1, 1];
		turnBottomClockwiseFaces[5, 0, 0] = Faces[5, 1, 0];
		turnBottomClockwiseFaces[5, 1, 0] = Faces[5, 1, 1];
		turnBottomClockwiseFaces[5, 1, 1] = Faces[5, 0, 1];
		turnBottomClockwiseFaces[5, 0, 1] = Faces[5, 0, 0];
		TurnBottomClockwiseCubeState = ProcessFaces(turnBottomClockwiseFaces, TurnBottomClockwiseCubeState, allCubeStates, queue);
		TurnBottomClockwiseCubeState.TurnBottomAnticlockwiseCubeState = this;

		var turnBottomAnticlockwiseFaces = DeepCopyFaces();
		turnBottomAnticlockwiseFaces[0, 1, 0] = Faces[1, 1, 0];
		turnBottomAnticlockwiseFaces[0, 1, 1] = Faces[1, 1, 1];
		turnBottomAnticlockwiseFaces[1, 1, 0] = Faces[2, 1, 0];
		turnBottomAnticlockwiseFaces[1, 1, 1] = Faces[2, 1, 1];
		turnBottomAnticlockwiseFaces[2, 1, 0] = Faces[3, 1, 0];
		turnBottomAnticlockwiseFaces[2, 1, 1] = Faces[3, 1, 1];
		turnBottomAnticlockwiseFaces[3, 1, 0] = Faces[0, 1, 0];
		turnBottomAnticlockwiseFaces[3, 1, 1] = Faces[0, 1, 1];
		turnBottomAnticlockwiseFaces[5, 0, 0] = Faces[5, 0, 1];
		turnBottomAnticlockwiseFaces[5, 0, 1] = Faces[5, 1, 1];
		turnBottomAnticlockwiseFaces[5, 1, 1] = Faces[5, 1, 0];
		turnBottomAnticlockwiseFaces[5, 1, 0] = Faces[5, 0, 0];
		TurnBottomAnticlockwiseCubeState = ProcessFaces(turnBottomAnticlockwiseFaces, TurnBottomAnticlockwiseCubeState, allCubeStates, queue);
		TurnBottomAnticlockwiseCubeState.TurnBottomClockwiseCubeState = this;

		var turnRightClockwiseFaces = DeepCopyFaces();
		turnRightClockwiseFaces[0, 0, 1] = Faces[5, 0, 1];
		turnRightClockwiseFaces[0, 1, 1] = Faces[5, 1, 1];
		turnRightClockwiseFaces[4, 0, 1] = Faces[0, 0, 1];
		turnRightClockwiseFaces[4, 1, 1] = Faces[0, 1, 1];
		turnRightClockwiseFaces[2, 0, 0] = Faces[4, 1, 1];
		turnRightClockwiseFaces[2, 1, 0] = Faces[4, 0, 1];
		turnRightClockwiseFaces[5, 0, 1] = Faces[2, 1, 0];
		turnRightClockwiseFaces[5, 1, 1] = Faces[2, 0, 0];
		turnRightClockwiseFaces[1, 0, 0] = Faces[1, 1, 0];
		turnRightClockwiseFaces[1, 1, 0] = Faces[1, 1, 1];
		turnRightClockwiseFaces[1, 1, 1] = Faces[1, 0, 1];
		turnRightClockwiseFaces[1, 0, 1] = Faces[1, 0, 0];
		TurnRightClockwiseCubeState = ProcessFaces(turnRightClockwiseFaces, TurnRightClockwiseCubeState, allCubeStates, queue);
		TurnRightClockwiseCubeState.TurnRightAnticlockwiseCubeState = this;

		var turnRightAnticlockwiseFaces = DeepCopyFaces();
		turnRightAnticlockwiseFaces[0, 0, 1] = Faces[4, 0, 1];
		turnRightAnticlockwiseFaces[0, 1, 1] = Faces[4, 1, 1];
		turnRightAnticlockwiseFaces[4, 0, 1] = Faces[2, 1, 0];
		turnRightAnticlockwiseFaces[4, 1, 1] = Faces[2, 0, 0];
		turnRightAnticlockwiseFaces[2, 0, 0] = Faces[5, 1, 1];
		turnRightAnticlockwiseFaces[2, 1, 0] = Faces[5, 0, 1];
		turnRightAnticlockwiseFaces[5, 0, 1] = Faces[0, 0, 1];
		turnRightAnticlockwiseFaces[5, 1, 1] = Faces[0, 1, 1];
		turnRightAnticlockwiseFaces[1, 0, 0] = Faces[1, 0, 1];
		turnRightAnticlockwiseFaces[1, 0, 1] = Faces[1, 1, 1];
		turnRightAnticlockwiseFaces[1, 1, 1] = Faces[1, 1, 0];
		turnRightAnticlockwiseFaces[1, 1, 0] = Faces[1, 0, 0];
		TurnRightAnticlockwiseCubeState = ProcessFaces(turnRightAnticlockwiseFaces, TurnRightAnticlockwiseCubeState, allCubeStates, queue);
		TurnRightAnticlockwiseCubeState.TurnRightClockwiseCubeState = this;

		var turnBackClockwiseFaces = DeepCopyFaces();
		turnBackClockwiseFaces[1, 0, 1] = Faces[5, 1, 1];
		turnBackClockwiseFaces[1, 1, 1] = Faces[5, 1, 0];
		turnBackClockwiseFaces[4, 0, 0] = Faces[1, 0, 1];
		turnBackClockwiseFaces[4, 0, 1] = Faces[1, 1, 1];
		turnBackClockwiseFaces[3, 0, 0] = Faces[4, 0, 1];
		turnBackClockwiseFaces[3, 1, 0] = Faces[4, 0, 0];
		turnBackClockwiseFaces[5, 1, 0] = Faces[3, 0, 0];
		turnBackClockwiseFaces[5, 1, 1] = Faces[3, 1, 0];
		turnBackClockwiseFaces[2, 0, 0] = Faces[2, 1, 0];
		turnBackClockwiseFaces[2, 0, 1] = Faces[2, 1, 1];
		turnBackClockwiseFaces[2, 1, 1] = Faces[2, 0, 1];
		turnBackClockwiseFaces[2, 1, 0] = Faces[2, 0, 0];
		TurnBackClockwiseCubeState = ProcessFaces(turnBackClockwiseFaces, TurnBackClockwiseCubeState, allCubeStates, queue);
		TurnBackClockwiseCubeState.TurnBackAnticlockwiseCubeState = this;

		var turnBackAnticlockwiseFaces = DeepCopyFaces();
		turnBackAnticlockwiseFaces[1, 0, 1] = Faces[4, 0, 0];
		turnBackAnticlockwiseFaces[1, 1, 1] = Faces[4, 0, 1];
		turnBackAnticlockwiseFaces[4, 0, 0] = Faces[3, 1, 0];
		turnBackAnticlockwiseFaces[4, 0, 1] = Faces[3, 0, 0];
		turnBackAnticlockwiseFaces[3, 0, 0] = Faces[5, 1, 0];
		turnBackAnticlockwiseFaces[3, 1, 0] = Faces[5, 1, 1];
		turnBackAnticlockwiseFaces[5, 1, 0] = Faces[1, 1, 1];
		turnBackAnticlockwiseFaces[5, 1, 1] = Faces[1, 0, 1];
		turnBackAnticlockwiseFaces[2, 0, 0] = Faces[2, 0, 1];
		turnBackAnticlockwiseFaces[2, 0, 1] = Faces[2, 1, 1];
		turnBackAnticlockwiseFaces[2, 1, 0] = Faces[2, 1, 0];
		turnBackAnticlockwiseFaces[2, 1, 1] = Faces[2, 0, 0];
		TurnBackAnticlockwiseCubeState = ProcessFaces(turnBackAnticlockwiseFaces, TurnBackAnticlockwiseCubeState, allCubeStates, queue);
		TurnBackAnticlockwiseCubeState.TurnBackClockwiseCubeState = this;
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
