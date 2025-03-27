import { Link } from "react-router-dom"

export const Navbar = () => {
  return (
    <nav>
      <section>
        <h1>Management App</h1>

        <div className="navContent">
          <div className="navLinks">
            <Link to="/">Positions</Link>
          </div>
        </div>
      </section>
    </nav>
  )
}
