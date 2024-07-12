import { Link } from 'react-router-dom';
import '../../styles/Header.css';
const Header = () => {
    return (
        <header className="header">
            <div className="container">
                <nav className='navbar'>
                    <Link to="/">PERSONEL WEB</Link>
                    <ul>
                        <li><Link to="/create">CREATE</Link></li>
                    </ul>
                </nav>
            </div>
        </header>
    );
}
export default Header;
