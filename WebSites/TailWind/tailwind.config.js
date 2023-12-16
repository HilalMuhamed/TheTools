/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./public/**/*.{html,js}"],
  theme: {
    extend: {
      fontSize:{mamath:'8rem'},
      colors:{primary:'#fabf0f'},
      fontFamily:{body:['Anton']},
      letterSpacing:{a:'1em'}
    },
  },
  plugins: [],
}

