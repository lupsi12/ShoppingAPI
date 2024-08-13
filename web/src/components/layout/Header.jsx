import { Link } from 'react-router-dom';
import NotificationsIcon from '@mui/icons-material/Notifications';
import SearchIcon from '@mui/icons-material/Search';
import '../../styles/Header.css';
import headerImage from '../../img/header.png';
import {useEffect, useState} from "react";
import {fetchData} from "../../api/FetchAPI";

const Header = () => {
    const [categoryData,setCategoryData] = useState([]);
    useEffect(() => {
        const fetchCategoryData = async () => {
            try {
                const url = 'http://localhost:5250/api/category'; // Örnek bir API URL'i
                const data = await fetchData(url); // fetchData fonksiyonu ile veriyi alıyoruz
                setCategoryData(data); // Alınan veriyi state'e atıyoruz
            } catch (error) {
                console.error('Error fetching personnel data:', error);
            }
        };
        fetchCategoryData(); // useEffect içinde fetch işlemi yapmak için çağırıyoruz
    }, []);
    return (
        <header className="header">
            <div className="header-main">
                <div className="header-container">
                    <div className="header-container-main">
                        <div className="skrill-logo">
                            <img src={headerImage} alt="Resim Açıklaması"/>
                        </div>
                        <div className="input-space">
                            <input type="text" tabIndex="1" maxLength="50" placeholder="Aradığınız ürün, kategori veya üreticiyi yazınız" value=""/>
                            <div className="search">
                                <SearchIcon style={{ color: 'rgba(134,33,101,255)' , fontSize: '23px', marginRight: '10px', marginLeft: '4px', paddingTop: '6px' }} />
                            </div>
                        </div>
                        <div className="col-auto">
                            <div className="account">
                                <a href="/create"> Giriş Yap / Üye Ol</a>
                            </div>
                        </div>
                        <div className="col-12">
                            <div className="megamenu">
                                <div className="megamenu-items">
                                    <div className="dropdown">
                                        <div className="megamenu-items-item">
                                            <a href="/create">
                                                Kategoriler
                                            </a>
                                        </div>
                                        <div className="dropdown-alt">
                                            <div className="dropdown-alt-design">
                                                {categoryData.map((i) => (
                                                    <a href={`/create`} key={i.id}>
                                                        {i.name}
                                                    </a>
                                                ))}

                                            </div>
                                        </div>
                                    </div>

                                    <div className="megamenu-items-item">
                                        <a href="/deneme">
                                        Satıcılar
                                        </a>
                                    </div>
                                    <div className="megamenu-items-item">
                                    <a href="/deneme">
                                            Kullanıcılar
                                        </a>
                                    </div>
                                    <div className="megamenu-items-item">
                                        <div className="offer">
                                            <a href="/deneme"><NotificationsIcon style={{ color: 'rgba(183,48,145,255)' , fontSize: '17px', marginRight: '5px', marginLeft: '3px' }} />
                                            Kampanyalar
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
    );
}
export default Header;
