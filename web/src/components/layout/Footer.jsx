import '../../styles/Footer.css';
import headerImage from '../../img/header.png';
import InstagramIcon from "@mui/icons-material/Instagram";
import TwitterIcon from "@mui/icons-material/Twitter";
const Footer = () => {
    return (
        <footer className="footer">
            <div className='logo-container'>
                <img src={headerImage} alt="Resim Açıklaması" />
            </div>
            <div className='social-media'>
                <div className='icon'>
                    <a href="https://www.instagram.com/" target="_blank" rel="noopener noreferrer" >
                        <InstagramIcon style={{ color: 'white', fontSize: '50px' }} />
                    </a>
                </div>
                <div className='icon'>
                    <a href="https://twitter.com/" target="_blank" rel="noopener noreferrer" >
                        <TwitterIcon style={{ color: 'white', fontSize: '50px' }} />
                    </a>
                </div>
            </div>
            <div className='end-container'>
                <div className='first-con'>
                    <div className='menu-design'>
                        <h2>
                            Yardım ve Destek
                        </h2>
                        <ul className='lu'>
                            <li>
                                <a href="/bize-ulasin" title="" target="_self" rel="noopener noreferrer">Bize Ulaşın
                                </a>
                            </li>
                            <li>
                                <a href="/create" title="" target="_self" rel="noopener noreferrer">Şirket Bilgileri
                                </a>
                            </li>
                            <li>
                                <a href="/create" title="" target="_self" rel="noopener noreferrer"> Sıkça Sorulan Sorular</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className='second-con'>
                    <div className='menu-design'>
                        <h2>
                            Gizlilik ve Güvenlik
                        </h2>
                        <ul className='lu'>
                            <li>
                                <a href="/create" title="" target="_self" rel="noopener noreferrer">Üyelik Sözleşmesi
                                </a>
                            </li>
                            <li>
                                <a href="/create" title="" target="_self" rel="noopener noreferrer">Gizlilik Politikası
                                </a>
                            </li>
                            <li>
                                <a href="/create" title="" target="_self" rel="noopener noreferrer">Kişisel Verilerin Korunması</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className='another-con'>
                    <div >
                    </div>
                </div>
            </div>
        </footer>
    );
}
export default Footer;
