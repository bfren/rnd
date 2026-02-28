# Claude Code Guidelines for RndF Project

## Project Overview
RndF is a .NET project that includes:
- **RndF**: Main library for random number generation
- **RndF.Sodium**: Sodium cryptography bindings
- **Tests.RndF**: Test suite for the RndF library

## Building and Running Tests

### Build the project
```bash
dotnet build
```

### Run all tests
```bash
dotnet test
```

### Run specific project tests
```bash
dotnet test tests/Tests.RndF/Tests.RndF.csproj
```

## Development Workflow

### Before Starting Work
1. Fetch the latest changes from the remote
2. Check out the designated feature branch (e.g., `claude/update-claude-md-2Zmve`)

### Making Changes
1. Edit code in the relevant project directories:
   - Library code: `src/RndF/` or `src/RndF.Sodium/`
   - Tests: `tests/Tests.RndF/`
2. Run tests locally to verify changes work correctly
3. Follow the existing code style and patterns

### Committing Work
- Write clear, descriptive commit messages
- Commit to the designated feature branch only
- Do NOT commit to main/master without explicit permission

### Pushing Changes
- Always use: `git push -u origin <branch-name>`
- The branch name should start with 'claude/' and end with the matching session ID
- If push fails, retry up to 4 times with exponential backoff (2s, 4s, 8s, 16s)

## Important Guidelines

### When to Ask Before Acting
- **Destructive operations**: Before deleting files, branches, or resetting history
- **Hard-to-reverse changes**: Before force-pushing, amending published commits, or modifying CI/CD
- **Shared state**: Before pushing to main/master or creating/closing issues

### Code Quality
- Keep changes focused and minimal
- Don't over-engineer or add unnecessary abstractions
- Avoid adding features beyond what was requested
- Trust framework guarantees; only validate at system boundaries
- Delete unused code rather than leaving commented placeholders

### Testing
- Run tests before committing changes
- Ensure all existing tests pass
- Add tests for new functionality when appropriate

## Project Structure
```
/home/user/rnd/
├── src/
│   ├── RndF/              # Main library
│   └── RndF.Sodium/       # Sodium cryptography bindings
├── tests/
│   └── Tests.RndF/        # Test suite
├── Test.csproj            # Test project
└── CLAUDE.MD              # This file
```

## Useful dotnet Commands
- `dotnet build` - Build the solution
- `dotnet test` - Run all tests
- `dotnet test --no-build` - Run tests without rebuilding
- `dotnet clean` - Clean build artifacts
- `dotnet add <project> package <package-name>` - Add a NuGet package

## Notes
- This project uses .NET SDK 8.0 and 10.0
- All development should occur on designated feature branches
- Keep commits atomic and focused on single concerns
