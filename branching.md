save all progress
# If first time
`git branch <YourName>`
`git checkout <YourName>`
`git add .`
`git commit -s -m "<Message>"`
`git push --set-upstream origin <YourName>`
`git checkout main`
`git merge main <YourName>`

# Other Times
`git checkout <YourName>`
`git add .`
`git commit -s -m "<Message>"`
`git push <YourName>`
`git checkout main`
`git merge main <YourName>`