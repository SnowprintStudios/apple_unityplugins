using System;
using System.Runtime.InteropServices;
using Apple.Core;
using Apple.Core.Runtime;

namespace Apple.GameKit.Multiplayer
{
    using GKMatchProperties = NSDictionary<NSString, NSObject>;

    /// <summary>
    /// An object that encapsulates the parameters to create a real-time or turn-based match.
    /// </summary>
    public class GKMatchRequest : NSObject
    {
        /// <summary>
        /// A player's response to an invitation to join a match.
        /// </summary>
        public enum GKInviteRecipientResponse : long
        {
            /// <summary>
            /// A response when the player accepts the invitation
            /// </summary>
            Accepted = 0,
            /// <summary>
            /// A response when the player rejects the invitation.
            /// </summary>
            Declined = 1,
            /// <summary>
            /// A response when the system fails to deliver the invitation to the player.
            /// </summary>
            Failed = 2,
            /// <summary>
            /// A response when the player isn't running a compatible version of the game.
            /// </summary>
            Incompatible = 3,
            /// <summary>
            /// A response when the system can't contact the player.
            /// </summary>
            UnableToConnect = 4,
            /// <summary>
            /// A response when the invitation times out because the player doesn't answer it.
            /// </summary>
            NoAnswer = 5
        }
        
        /// <summary>
        /// The kind of match managed by Game Center.
        /// </summary>
        public enum GKMatchType : ulong
        {
            /// <summary>
            /// A peer-to-peer match hosted by Game Center.
            /// </summary>
            PeerToPeer = 0,
            /// <summary>
            /// A match hosted on your private server.
            /// </summary>
            Hosted = 1,
            /// <summary>
            /// A turn-based match hosted by Game Center.
            /// </summary>
            TurnBased = 2
        }
        
        internal GKMatchRequest(IntPtr pointer) : base(pointer)
        {
        }
        
        /// <summary>
        /// The maximum number of players that can join the match.
        /// </summary>
        public long MaxPlayers
        {
            get => Interop.GKMatchRequest_GetMaxPlayers(Pointer);
            set => Interop.GKMatchRequest_SetMaxPlayers(Pointer, value);
        }
        
        /// <summary>
        /// The minimum number of players that can join the match.
        /// </summary>
        public long MinPlayers
        {
            get => Interop.GKMatchRequest_GetMinPlayers(Pointer);
            set => Interop.GKMatchRequest_SetMinPlayers(Pointer, value);
        }
        
        /// <summary>
        /// A number identifying a subset of players invited to join a match.
        /// </summary>
        public long PlayerGroup
        {
            get => Interop.GKMatchRequest_GetPlayerGroup(Pointer);
            set => Interop.GKMatchRequest_SetPlayerGroup(Pointer, value);
        }
        
        /// <summary>
        /// A mask that specifies the role that the local player would like to play in the game.
        /// </summary>
        public uint PlayerAttributes
        {
            get => Interop.GKMatchRequest_GetPlayerAttributes(Pointer);
            set => Interop.GKMatchRequest_SetPlayerAttributes(Pointer, value);
        }
        
        /// <summary>
        /// The message sent to other players when the local player invites them to join a match.
        /// </summary>
        public string InviteMessage
        {
            get => Interop.GKMatchRequest_GetInviteMessage(Pointer);
            set => Interop.GKMatchRequest_SetInviteMessage(Pointer, value);
        }
        
        /// <summary>
        /// The players to invite to the match.
        /// </summary>
        public NSArray<GKPlayer> Recipients
        {
            get => PointerCast<NSArray<GKPlayer>>(Interop.GKMatchRequest_GetRecipients(Pointer));
            set => Interop.GKMatchRequest_SetRecipients(Pointer, value.Pointer);
        }

        /// <summary>
        /// The name of the queue that Game Center places the match request in.
        /// </summary>
        [Introduced(iOS: "17.2", macOS: "14.2", tvOS: "17.2")]
        public string QueueName
        {
            get => Interop.GKMatchRequest_GetQueueName(Pointer);
            set => Interop.GKMatchRequest_SetQueueName(Pointer, value);
        }

        /// <summary>
        /// The criteria for the local player that Game Center uses to find other players when using matchmaking rules.
        /// </summary>
        [Introduced(iOS: "17.2", macOS: "14.2", tvOS: "17.2")]
        public GKMatchProperties Properties
        {
            get => PointerCast<GKMatchProperties>(Interop.GKMatchRequest_GetProperties(Pointer));
            set => Interop.GKMatchRequest_SetProperties(Pointer, value?.Pointer ?? IntPtr.Zero);
        }

        /// <summary>
        /// The criteria for recipients of the match request that Game Center uses to find other players when using matchmaking rules.
        /// </summary>
        [Introduced(iOS: "17.2", macOS: "14.2", tvOS: "17.2")]
        public NSDictionary<GKPlayer, GKMatchProperties> RecipientProperties
        {
            get => PointerCast<NSDictionary<GKPlayer, GKMatchProperties>>(Interop.GKMatchRequest_GetRecipientProperties(Pointer));
            set => Interop.GKMatchRequest_SetRecipientProperties(Pointer, value?.Pointer ?? IntPtr.Zero);
        }

        public static GKMatchRequest Init()
        {
            return PointerCast<GKMatchRequest>(Interop.GKMatchRequest_Init());
        }

        private static class Interop
        {
            [DllImport(InteropUtility.DLLName)]
            public static extern long GKMatchRequest_GetMaxPlayers(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetMaxPlayers(IntPtr pointer, long maxPlayers);
            [DllImport(InteropUtility.DLLName)]
            public static extern long GKMatchRequest_GetMinPlayers(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetMinPlayers(IntPtr pointer, long maxPlayers);
            [DllImport(InteropUtility.DLLName)]
            public static extern long GKMatchRequest_GetPlayerGroup(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetPlayerGroup(IntPtr pointer, long maxPlayers);
            [DllImport(InteropUtility.DLLName)]
            public static extern uint GKMatchRequest_GetPlayerAttributes(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetPlayerAttributes(IntPtr pointer, uint value);
            [DllImport(InteropUtility.DLLName)]
            public static extern string GKMatchRequest_GetInviteMessage(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetInviteMessage(IntPtr pointer, string value);
            [DllImport(InteropUtility.DLLName)]
            public static extern IntPtr GKMatchRequest_GetRecipients(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetRecipients(IntPtr pointer, IntPtr value);
            [DllImport(InteropUtility.DLLName)]
            public static extern string GKMatchRequest_GetQueueName(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void  GKMatchRequest_SetQueueName(IntPtr pointer, string value);
            [DllImport(InteropUtility.DLLName)]
            public static extern IntPtr GKMatchRequest_GetProperties(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetProperties(IntPtr pointer, IntPtr value);
            [DllImport(InteropUtility.DLLName)]
            public static extern IntPtr GKMatchRequest_GetRecipientProperties(IntPtr pointer);
            [DllImport(InteropUtility.DLLName)]
            public static extern void GKMatchRequest_SetRecipientProperties(IntPtr pointer, IntPtr value);
            [DllImport(InteropUtility.DLLName)]
            public static extern IntPtr GKMatchRequest_Init();
        }
    }
}
