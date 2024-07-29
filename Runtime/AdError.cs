namespace com.ktgame.ads.core
{
    public class AdError
    {
        public readonly AdPlacement Placement;
        public readonly AdErrorCode ErrorCode;
        public readonly string Message;

        public AdError(AdPlacement placement, AdErrorCode errorCode, string message)
        {
            Placement = placement;
            ErrorCode = errorCode;
            Message = message;
        }
    }
}