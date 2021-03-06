﻿using System;
namespace NuGetGallery
{
    using System.ComponentModel.DataAnnotations;

    public class PackageViewModel : IPackageVersionModel
    {
        readonly Package package;

        public PackageViewModel(Package package)
        {
            this.package = package;
            Version = package.Version;
            Description = package.Description;
            ReleaseNotes = package.ReleaseNotes;
            IconUrl = package.IconUrl;
            ProjectUrl = package.ProjectUrl;
            LicenseUrl = package.LicenseUrl;
            LatestVersion = package.IsLatest;
            LatestStableVersion = package.IsLatestStable;
            LastUpdated = package.Published;
            Listed = package.Listed;
            DownloadCount = package.DownloadCount;
            Prerelease = package.IsPrerelease;
            Status = package.Status;
            ApprovedDate = package.ApprovedDate;
            ReviewedByUserName = package.ReviewedBy !=null ? package.ReviewedBy.Username : string.Empty;
            ReviewedDate = package.ReviewedDate;
            ReviewComments = package.ReviewComments;
        }

        public string Id
        {
            get
            {
                return package.PackageRegistration.Id;
            }
        }
        public string Version { get; set; }
        public string Title
        {
            get
            {
                return String.IsNullOrEmpty(package.Title) ? package.PackageRegistration.Id : package.Title;
            }
        }
        public string Description { get; set; }
        public string ReleaseNotes { get; set; }
        public string IconUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string LicenseUrl { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool LatestVersion { get; set; }
        public bool LatestStableVersion { get; set; }
        public bool Prerelease { get; set; }
        public int DownloadCount { get; set; }
        public bool Listed { get; set; }
        [Display(Name = "Package Status")]
        public PackageStatusType Status { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public string ReviewedByUserName { get; set; }
        [Display(Name = "Review Comments")]
        public string ReviewComments { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public int TotalDownloadCount
        {
            get
            {
                return package.PackageRegistration.DownloadCount;
            }
        }

        public bool IsCurrent(IPackageVersionModel current)
        {
            return current.Version == Version && current.Id == Id;
        }
    }
}