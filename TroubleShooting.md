# Troubleshooting

## GitHub MCP Integration Issue

### Problem

I was unable to connect the MCP server to my GitHub repository. The integration kept failing, and I couldn't perform write operations.

### Cause

By default, for public repositories, the GitHub token permissions are set to read-only. This prevents MCP or other automation tools from making changes such as pushing commits, updating issues, or managing repository contents.

### Solution

I updated the repository token permissions to grant Read and Write access for the following scopes:

- Actions
- Commit Statuses
- Contents
- Issues
- Administration

After changing these permissions, the MCP integration worked as expected and I was able to perform all necessary operations.
