namespace FixMusic
{
    public interface ITrackCommand
    {
        void Execute(ITrack track, ITrackCollection collection);
    }
}
