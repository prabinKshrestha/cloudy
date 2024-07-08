import { DarkThemeToggle, Navbar } from "flowbite-react";

export default function MyNavBar() {
    return (
        <nav>
            <Navbar fluid border>
                <Navbar.Brand href="/">
                    <span className="self-center whitespace-nowrap text-2xl font-semibold dark:text-white">Cloudy</span>
                </Navbar.Brand>
                <Navbar.Collapse>
                    <Navbar.Link href="#" active>
                        Home
                    </Navbar.Link>
                    <Navbar.Link href="#">
                        GitHub
                    </Navbar.Link>
                </Navbar.Collapse>
                <DarkThemeToggle />
                <Navbar.Toggle />
            </Navbar>
        </nav>
    );
}