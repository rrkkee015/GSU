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

## AI Model Selection and Prompt Chaining

### Problem

I used the supposedly superior Max Mode abstract model (Claude-3.7-Sonnet) but experienced unexpected slowness and numerous errors in the output.

### Cause

Even with an advanced model, providing extensive and complex requirements in a single prompt did not yield the expected results. The model didn't automatically produce 100% of what was needed despite its capabilities. Additionally, the slow processing speed negatively impacted productivity.

### Solution

I switched to Auto mode for model performance and implemented prompt chaining techniques instead of providing all requirements at once. This approach reduced the complexity of individual prompts and improved the overall guidance process. Using this method, I was able to successfully resolve the issue at https://github.com/rrkkee015/GSU/issues/20 with better efficiency and higher quality results.
