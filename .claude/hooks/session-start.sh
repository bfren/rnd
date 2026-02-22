#!/bin/bash
set -euo pipefail

# Only run in remote (web) environments
if [ "${CLAUDE_CODE_REMOTE:-}" != "true" ]; then
  exit 0
fi

# Fix /tmp permissions for apt-get to work correctly
chmod 1777 /tmp

# Install .NET SDKs via apt (8.0 and 10.0 are available in Ubuntu 24.04 repos)
apt-get update -qq
apt-get install -y --no-install-recommends dotnet-sdk-8.0 dotnet-sdk-10.0

# Persist environment variables for the session
echo 'export DOTNET_CLI_TELEMETRY_OPTOUT=1' >> "$CLAUDE_ENV_FILE"
echo 'export DOTNET_NOLOGO=1' >> "$CLAUDE_ENV_FILE"

# Restore NuGet packages
cd "$CLAUDE_PROJECT_DIR"
dotnet restore Test.csproj
