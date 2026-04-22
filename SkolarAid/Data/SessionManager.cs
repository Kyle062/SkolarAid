using System;
using SkolarAid.Models;

namespace SkolarAid.Classes
{
    public static class SessionManager
    {
        // Current logged-in user
        public static User CurrentUser { get; private set; }

        // Current scholar (if logged in as scholar)
        public static Scholar CurrentScholar { get; private set; }

        // Check if user is logged in
        public static bool IsLoggedIn => CurrentUser != null;

        // Check if current user is admin
        public static bool IsAdmin => CurrentUser?.Role == "ADMIN";

        // Check if current user is scholar
        public static bool IsScholar => CurrentUser?.Role == "SCHOLAR";

        // Set current user (called after successful login)
        public static void SetCurrentUser(User user, Scholar scholar = null)
        {
            CurrentUser = user;
            CurrentScholar = scholar;
        }

        // Clear session (called on logout)
        public static void ClearSession()
        {
            CurrentUser = null;
            CurrentScholar = null;
        }

        // Get current user's display name
        public static string GetDisplayName()
        {
            if (CurrentUser == null) return "Guest";

            if (IsScholar && CurrentScholar != null)
                return CurrentScholar.FullName;

            return CurrentUser.Name;
        }

        // Get current scholar ID (if applicable)
        public static int? GetCurrentScholarId()
        {
            return CurrentScholar?.Id;
        }
    }
}