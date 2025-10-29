# Main Title

## Section

### Subsection

#### Sub-subsection

This is **bold text**.
This is _italic text_.
This is **_bold and italic_**.

- Item 1
- Item 2
  - Nested Item 2.1
  - Nested Item 2.2

* Item 3

1. First item
2. Second item
   1. Nested ordered item
   2. Another nested item
3. Third item
   Visit [Google](https://www.google.com "Search Engine") for more information.
   ![A beautiful sunset](images/sunset.jpg "Gorgeous Sunset")
   Use the `console.log()` function to debug.

```javascript
function greet(name) {
  return `Hello, ${name}!`;
}
console.log(greet("World"));
```

```html
<!DOCTYPE html>
<html lang="en">
  <body>
    <h1>Hello!</h1>
  </body>
</html>
```

---

This is content after a horizontal rule.

---

| Header 1    | Header 2    | Header 3    |
| ----------- | ----------- | ----------- |
| Row 1 Col 1 | Row 1 Col 2 | Row 1 Col 3 |
| Row 2 Col 1 | Row 2 Col 2 | Row 2 Col 3 |

- [x] Task completed
- [ ] Task not completed

pandoc [input_file] [output_options] [filters_and_extensions]

pandoc my_document.md -o my_document.html
pandoc my_document.md -o my_document.pdf
