﻿using System;
using Xunit;
using FluentAssertions;

namespace WordPressKata.Tests
{
    public class LoginShould
    {
        [Fact]
        public void AllowAnAdminToLogin()
        {
            LoginPage.GoTo();

            LoginPage
                .LoginAs("admin")
                .WithPassword("password")
                .Login();

            DashboardPage.IsCurrentPage.Should().BeTrue();
        }
    }
}
